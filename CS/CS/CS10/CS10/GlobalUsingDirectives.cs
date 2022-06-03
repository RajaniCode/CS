// 4. global using directives
class GlobalUsingDirectives
{
    public string Reverse(string text)
    {
 	StringBuilder build = new StringBuilder(text);
	return new string(build.ToString().Reverse().ToArray());
    }
}

