public class FlipandKey
{
    /// <summary>
    /// Function to validate the input and then return the key if applicable
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public string CleanseAndInvert(string input)
    {

        if(string.IsNullOrEmpty(input) || input.Length < 6)//Chrck if string is Valid  or not null
        {
            return (string.Empty);
        }
        for (int i = 0; i < input.Length; i++)
        {
            char ch=input[i];
            if (!char.IsLetter(ch))
            {
                return (string.Empty);
            }
        }

        //converting the input to lower
        input=input.ToLower();
        //removing all character whose ASCII are even
        string cleansed="";
        foreach(char ch in input)
        {
            if ((int)ch % 2 != 0)
            {
                cleansed+=ch;
            }
        }   
        //Reversing the cleansed string
        Char[] cha=cleansed.ToCharArray();
        Array.Reverse(cha);
        
        //Uppercase
        for(int i = 0; i < cha.Length; i++)
        {
            if (i % 2 == 0)
            {
                cha[i]=char.ToUpper(cha[i]);
            }
        }

        //Convert chararcter array to String
        return new string(cha);

    }
}