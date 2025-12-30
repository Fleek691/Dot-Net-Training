namespace IndexerExample
{
    /// <summary>
    /// Internal Class For Indexer Example
    /// </summary>
    class MyData
    {
    private string[] values=new string[3];//indexer initialization -indexer is like a feild but for collection
    public string this[int index]
    {
        get
        {
            return values[index];//returns the value at that index
        }
        set
        {
            values[index]=value;//sets the value for that particular index
        }
    }
}
}