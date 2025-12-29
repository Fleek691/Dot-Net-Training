class Student
{
    public int RollNo{get;set;}
    public string Name{get;set;}
    private string _Address;
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
            return string.IsNullOrEmpty(this._address)?"No Value":this._address;
        }
    }
    private string[] books=new string[2];
    public string this[int index]
    {
        get
        {
            return books[index];
        }
        set
        {
            books[index]=value;
        }
    }
}