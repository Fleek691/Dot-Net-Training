public class Employee
{
    public int Id{get;set;}
    public string Name{get;set;}
    public int Salary{get;set;}

    private Employee(){}

    private void Validate(int id,string name,int salary)
    {
        string error="";
        if (id <= 0)
        {
            error+="Id cannot be less than 0";
        }
        else if (string.IsNullOrEmpty(name))
        {
            error+="Name cannot be empty";
        }
        else if (salary <= 0)
        {
            error+="Salary cannot be";
        }
        else if (!string.IsNullOrEmpty(error))
        {
            throw new Exception(error);
        }
    }

    public Employee(int id)
    {
        Validate(id,"NA",1);
        Id=id;
    }

    public Employee(int id,string name)
    {
        Validate(id,name,1);
        Id=id;
        Name=name;
    }

    public  Employee(int id,string name,int salary)
    {
        Validate(id,name,salary);
        Id=id;
        Name=name;
        Salary=salary;
    }
}