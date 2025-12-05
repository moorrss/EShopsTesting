using System.Net.Sockets;
using System.Reflection;

namespace domain;

public class Customer()
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";


    public bool SaveCusomter()
    {
        if (FirstName.Length > 0 && LastName.Length > 0 && Email.Length > 0)
        {
            return true;
        }
        throw new ArgumentException("Information saknas");
    }

    public bool UpdateCusomter()
    {
        if (LastName.Trim().Length > 0 && Email.Trim().Length > 0)
        {
            return true;
        }
        throw new ArgumentException("Information saknas");
    }
}
