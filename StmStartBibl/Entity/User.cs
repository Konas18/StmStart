
namespace StmStartBibl
{
    public class User
    {

        public static string Login;
        public static string Password;
        public static string Surname;
        public static string Name;
        public static string Lastname;
        public static string PhoneNumber;
        public virtual string GetFullName
        {
            get
            {
                string temp = $"{Surname} {Name} ";
                if (Lastname != null) temp += $"{Lastname}";
                return temp;
            }
        }
    }

}
