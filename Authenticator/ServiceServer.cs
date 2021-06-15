using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.IO;
using AuthenticatorInterface;

//Done by R.W.A.D.U.Rajapakshe 20547312
namespace Authenticator
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ServiceServer : ServiceInterface
    {
        private readonly Random rand = new Random();

        public String Register(String name, String password){

            Boolean flag = false;

            try
            {
                //read and store the details in register.txt
                List<string> data = File.ReadAllLines("register.txt").ToList();

                //Add the details given to the text
                data.Add(name + "-" + password);

                //Write the details to the file with the newly entered data
                File.WriteAllLines("register.txt", data);

                //Assign all the details to user details
                List<string> userDetails = File.ReadAllLines("register.txt").ToList();

                //check if the value entered is saved to see whether the registration was successful.
                foreach (string uDetails in userDetails)
                {
                    string[] value = uDetails.Split('-');

                    string n1, p1;
                    n1 = value[0];
                    p1 = value[1];

                    if (n1.Equals(name) && p1.Equals(password))
                    {
                        flag = true;
                    }

                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e) {
                Console.WriteLine(e.Message);
            }

            if (flag == true)
                return "Successfully Registered";
            else
                return "Registration was unsuccessful";

        }

        public int Login(String name, String password) {

            int val;
            string n1, p1;

            List<string> data = File.ReadAllLines("register.txt").ToList();

            foreach (string uDetails in data)
            {
               string[] value = uDetails.Split('-');

               n1 = value[0];
               p1 = value[1];

                //generate and save the random number only if the name and password is validated.
                if (n1.Equals(name) && p1.Equals(password))
                {
                    val = rand.Next(0, 100000);
                    List<string> d1 = File.ReadAllLines("token.txt").ToList();
                    foreach (string details in d1) {
                        while (Convert.ToInt32(details) == val) {
                            val = rand.Next(0, 100000);
                        }
                    }
                    d1.Add(val.ToString());
                    File.WriteAllLines("token.txt", d1);
                    return val;
                }

            }
            return -1;
        }

        //Validate the entered token with the tokens saved in the local file
        public String validate(int token) {
            List<string> data = File.ReadAllLines("token.txt").ToList();
            foreach (string uDetails in data)
            {
                try
                {
                    if (Convert.ToInt32(uDetails) == token) {
                        return "validated";
                    }
                }
                catch (FormatException e) {
                    Console.WriteLine(e.Message);
                }catch(OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return "not validated";
        }
    }
}
