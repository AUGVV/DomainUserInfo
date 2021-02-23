using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.AccountManagement;

namespace READDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------DOMAIN READ-------------------\n");
                Console.ResetColor();

                Console.WriteLine("Введите имя пользователя (Test.T)\n");
                string User = Console.ReadLine();
                Console.WriteLine("\n");

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------USER INFO-------------------\n");
                Console.ResetColor();
                try
                {
                    using (PrincipalContext Context = new PrincipalContext(ContextType.Domain))
                    {
                        UserPrincipal Account = UserPrincipal.FindByIdentity(Context, $"{User}"); ;
                         
                        Console.WriteLine($"Name: {Account.Name}\n\n" +
                                          $"EmailAddress: {Account.EmailAddress}\n" +
                                          $"UserPrincipalName: {Account.UserPrincipalName}\n" +
                                          $"DisplayName: {Account.DisplayName}\n" +
                                          $"DistinguishedName: {Account.DistinguishedName}\n" +
                                          $"GivenName: {Account.GivenName}\n" +
                                          $"MiddleName: {Account.MiddleName}\n" +
                                          $"Surname: {Account.Surname}\n" +
                                          $"VoiceTelephoneNumber: {Account.VoiceTelephoneNumber}\n\n" +
                                          $"Sid: {Account.Sid}\n" +
                                          $"Guid: {Account.Guid}\n\n" +
                                          $"Enabled: {Account.Enabled}\n" +
                                          $"SamAccountName: {Account.SamAccountName}\n" +
                                          $"DelegationPermitted: {Account.DelegationPermitted}\n" +
                                          $"AccountExpirationDate: {Account.AccountExpirationDate}\n" +
                                          $"LastBadPasswordAttempt: {Account.LastBadPasswordAttempt}\n" +
                                          $"LastLogon: {Account.LastLogon}\n" +
                                          $"LastPasswordSet: {Account.LastPasswordSet}\n" +
                                          $"UserCannotChangePassword: {Account.UserCannotChangePassword}\n" +
                                          $"PasswordNeverExpires: {Account.PasswordNeverExpires}\n" +
                                          $"PasswordNotRequired: {Account.PasswordNotRequired}\n\n" +
                                          $"BadLogonCount: {Account.BadLogonCount}\n\n" +
                                          $"HomeDirectory: {Account.HomeDirectory}\n" +
                                          $"HomeDrive: {Account.HomeDrive}\n" +
                                          $"EmployeeId: {Account.EmployeeId}\n" +
                                          $"Description: {Account.Description}\n" +
                                          $"AccountLockoutTime: {Account.AccountLockoutTime}\n\n" +
                                          $"Context: {Account.Context}\n" +
                                          $"ContextType: {Account.ContextType}\n" +
                                          $"AllowReversiblePasswordEncryption: {Account.AllowReversiblePasswordEncryption}\n" +
                                          $"PermittedLogonTimes: {Account.PermittedLogonTimes}\n" +
                                          $"ScriptPath: {Account.ScriptPath}\n\n" +
                                          $"SmartcardLogonRequired: {Account.SmartcardLogonRequired}\n\n" +
                                          $"StructuralObjectClass: {Account.StructuralObjectClass}\n\n" +
                                          $"-------------------COMP INFO----------------------\n\n" +
                                          $"UserDomainName: {Environment.UserDomainName}\n" +
                                          $"MachineName: {Environment.MachineName}\n" +
                                          $"OSVersion: {Environment.OSVersion}\n" +
                                          $"UserName: {Environment.UserName}\n" +
                                          $"UserInteractive: {Environment.UserInteractive}\n" +
                                          $"WorkingSet: {Environment.WorkingSet}\n" +
                                          $"UserName: {Environment.UserName}\n" +
                                          $"ProcessorCount: {Environment.ProcessorCount}\n");

                        Console.WriteLine("(Проверка совпадения) Введите ФИО из СКУД\n");
                        string CMP = Console.ReadLine();
                        if (Account.ToString() == CMP)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nСовпадение есть\n");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nСовпадения нет\n");
                            Console.ResetColor();
                        }
                    }
                }
                catch (Exception ex) 
                { 
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.WriteLine($"Ошибка\n");
                    Console.ResetColor();
                }
            }
        }
    }
}
