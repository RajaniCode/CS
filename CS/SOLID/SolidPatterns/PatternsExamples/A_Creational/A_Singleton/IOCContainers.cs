// #region Copyright
// /* 
// ============================================================
// PatternsExamples - IOCContainers.cs
// All samples copyright 5/26/2013 Phil Japikse, www.skimedic.com
// see License.txt for license information
// ============================================================
// */
// Phil Japikse
// #endregion    
  
using PatternsExamples.B_Structural.B_Facade;
using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using PatternsExamples.C_Behavioral.Strategy;

namespace PatternsExamples.A_Creational.A_Singleton
{
	public class IOCContainer : IDisposable
	{
		private static volatile IOCContainer _instance;
		private static readonly object _syncLock = new object();
		private readonly IUnityContainer _container;

		private IOCContainer()
		{
			_container = new UnityContainer();
			_container.LoadConfiguration();
			//_container.RegisterType<IConfusing, Confusing>();
			//_container.RegisterType<IOverdone, Overdone>(new InjectionConstructor("foo"));
		}

		public static IOCContainer Instance
		{
			get
			{
				if (_instance != null) return _instance;
				lock (_syncLock)
				{
					if (_instance == null)
					{
						_instance = new IOCContainer();
					}
				}
				return _instance;
			}
		}

		public IBetterAPI GetFacadeForBadAPI() => _container.Resolve<BetterAPI>(new ParameterOverrides
		{
			{
				"someString",
				"foo"
			}
		});

		public ISuperPower GetSuperPower() => _container.Resolve<ISuperPower>();

		private bool _disposed = false;

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed) return;
			if (disposing)
			{
				_container.Dispose();
			}
			_disposed = true;
		}

		~IOCContainer()
		{
			Dispose(false);
		}
	}
}
