using System.Text;

public class Ques5
{
    public static void Main()
    {
        List<string>ops=["TYPE Hello","TYPE World","UNDO","TYPE CSharp"];
        StringBuilder newString=new StringBuilder();
        for(int i=0;i<ops.Count;i++){
            string temp="";
            string[] parts=ops[i].Split(" ");
            if (parts.Length > 1)
            {
                temp=parts[1]+" ";
            }
            else
            {
                parts=ops[i-1].Split(" ");
                temp=parts[1]+" ";
            }
            
            int count=temp.Length;
            if (ops[i].Contains("TYPE"))
            {
                
                newString.Append(temp);
            }
            else if (ops[i].Contains("UNDO"))
            {
                newString.Remove(newString.Length - count, count);
            }
            else
            {
                continue;
            }
        }
        System.Console.WriteLine(newString);

    }
}