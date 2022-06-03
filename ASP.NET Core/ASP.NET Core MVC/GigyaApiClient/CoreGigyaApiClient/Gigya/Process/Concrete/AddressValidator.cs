using System;
using System.Collections.Generic;
using System.Linq;
// Install-Package smartystreets-dotnet-sdk -Version 8.7.1
using SmartyStreets;
using SmartyStreets.USStreetApi;
using Gigya.Model.Models;
using Gigya.Process.Model;
using Gigya.Process.Abstract;
using Gigya.Common;

namespace Gigya.Process.Concrete
{
    public class AddressValidator : IAddressValidaor
    {
        #region Properties

        private readonly AppSettings appSetting;

        public bool IsErrored { get; private set; }

        public Dictionary<string, string> ErrorList { get; private set; }

        #endregion

        #region Constructor

        public AddressValidator()
        {
            appSetting = new AppSettings();
        }

        #endregion

        #region Public Methods

        public Tuple<bool, IDictionary<string, string>> ValidateAddress(Address address)
        {
            IsErrored = false;
            ErrorList = new Dictionary<string, string>();
            var validationErrorList = new Dictionary<string, string>();

            try
            {

                if (!address.PostalCode.Any(char.IsDigit))
                {
                    validationErrorList.Add("Invalid Address", "Invalid ZIP Code");
                    return new Tuple<bool, IDictionary<string, string>>(false, validationErrorList);
                }

                var ssClient = new ClientBuilder(appSetting.SmartyStreetsSettings.SmartyStreetsAuthId, appSetting.SmartyStreetsSettings.SmartyStreetsAuthToken).BuildUsStreetApiClient();

                // Convert the address
                var lookup = new Lookup
                {
                    Street = address.AddressLine1,
                    City = address.City,
                    State = address.State,
                    ZipCode = address.PostalCode,
                    MaxCandidates = 3,
                    MatchStrategy = Lookup.STRICT
                };

                ssClient.Send(lookup);
                Result validationResult = new Result();

                var candidates = lookup.Result;

                if (candidates.Count > 0)
                {
                    IsErrored = false;
                    validationResult.ErrorCode = "0";
                    validationResult.ErrorDescription = "At Least 1 Matching Address Found";
                    return new Tuple<bool, IDictionary<string, string>>(
                        validationResult.ErrorCode == "0",
                        new Dictionary<string, string>()
                        {
                        {
                            validationResult.ErrorCode, validationResult.ErrorDescription
                        }
                        }
                    );
                }
                else
                {
                    validationResult.ErrorCode = "No Matches";
                    validationResult.ErrorDescription = "No Matching Address Found";

                    return new Tuple<bool, IDictionary<string, string>>
                    (
                        validationResult.ErrorCode == "0",
                        new Dictionary<string, string>
                        {
                            {
                                validationResult.ErrorCode, validationResult.ErrorDescription
                            }
                        }
                    );
                }
            }
            catch (SmartyException ex)
            {
                validationErrorList.Add("Malformed Request", ex.Message);
                return new Tuple<bool, IDictionary<string, string>>(false, validationErrorList);
            }
            catch (Exception ex)
            {
                var log = ex.ToString();
                IsErrored = true;
            }

            return new Tuple<bool, IDictionary<string, string>>(false, new Dictionary<string, string>());
        }

        #endregion
    }
}