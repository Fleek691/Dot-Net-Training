using DAL;
namespace BLL
{
    public class BLLRevString
    {
        public string ReverseString()
        { 
            DALRevClass dalrev =new DALRevClass();

            string x = dalrev.GetAllNames();
            x=new string (x.Reverse().ToArray());
            return x;
        }
    }
}
