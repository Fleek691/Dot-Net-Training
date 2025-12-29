class Student
{
    public int RollNo{get;set;}//public variable for Roll No
    public string Name{get;set;}//public variable for Name
    private string _Address;//priavte filed for Address so others will not access it and make changes
    /// <summary>
    /// Property for the field _Address which sets and gets its value
    /// </summary>
    public string Address
    {
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Not a valid  Address");
            }
            this._Address=value;
        }
        get
        {
            return string.IsNullOrEmpty(this._Address)?"No Value":this._Address;
        }
    }
    // private string[] books=new string[2];//private indexer for storing book values in string format <- array type fixed though
    private List<String> books=new List<string>();//list 
    /// <summary>
    /// Get and set accessors  for private field book .
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public string this[int index]
    {
        get
        {
            return books[index];
        }
        set
        {
            while (index >= books.Count)
            {
                books.Add("");
            }
            books[index]=value;
        }
    }
}