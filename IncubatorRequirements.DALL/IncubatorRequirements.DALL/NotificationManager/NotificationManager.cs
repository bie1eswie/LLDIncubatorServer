using IncubatorRequirements.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;

namespace NotificationManager
{
    public class NotificationManager
    {
        public static void SendWellcomeLetter(string userEmail, string clientName, string otp,string username,string password)
        {
            string body = @"<table style=""background - color: #f6f6f6;width: 100%;"">
    <tr>
        <td></td>
        <td style = ""display: block !important;max-width: 600px !important;margin: 0 auto !important; clear: both !important;"" width = ""600"" >
   
               <div style = ""max-width: 600px;margin: 0 auto;display: block;padding: 20px;"" >
    
                    <table style = ""background: #fff;border: 1px solid #e9e9e9;border-radius: 3px;"" width = ""100%"" cellpadding = ""0"" cellspacing = ""0"" >
                               <tr>
           
                                   <td style = ""padding: 20px;"" >
            
                                        <table  cellpadding = ""0"" cellspacing = ""0"" >          
                                               <tr>              
                                                   <td>
               
                                                       <div style = ""color:#ffffff;background-color:#1ab394;border-color:#1ab394;height:50px;text-align: center;"" >
                                                            <h1 style=""text-align: center;"">Welcome to MyGrowthFund</h1>
                                                        </div>
                
                                                    </td>                
                                                </tr>                
                                                <tr>
                                                        <td style=""padding: 0 0 20px;"">
                 
                                                             <h3> Dear {0} </ h3 >
                                                        </td>
                                                    </tr>
                                                    <tr>
                    
                                                        <td style = ""padding: 0 0 20px;"" >
                                                            <strong>Verification Code: {1} </strong><br><br>
                                                            Thank you for registering with MyGrowthFund.<br><br>
															Please find your login details below to acess the registration platform. <br><br>
															<h4>Username:  {2}</h4>
															 <strong>Password:  {3}</strong>
                                                         </td>
                     
                                                     </tr>
                     
                                                     <tr>
                     
                                                         <td style = ""padding: 0 0 20px;"" >
                                                              Please follow the link below to continue with the registration process.
                                                          </td >
                      
                                                      </tr>
                      
                                                      <tr>
                                                          <td style = ""padding: 0 0 20px;text-align: center;"" >
                       
                                                               <a href = ""http://localhost:4200/#/confirmaccount"" style = ""text-decoration: none;color: #FFF;background-color: #1ab394;border: solid #1ab394;border-width: 5px 10px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block;border-radius: 5px;text-transform: capitalize;"" > Continue with Registration </ a >
                              
                                                                  </td>
                                                              </tr>
                                                                <td style=""padding: 0 0 20px;"">
                                                                    Thanks for choosing MyGrowthFund.
                                                                </td>                                                           </table>
                                                      </td>
                                                  </tr>                              
                                              </table>                              
                                              <div style = ""color: #999;"">     
                                                   <table width = ""100%"">                               
                                                        <tr>     
                                                            <td style = ""padding: 0 0 20px;text-align: center;"" > Follow < a href = ""#"" > @Company </ a > on Twitter.</ td >
                                                                     </tr>                         
                                                                 </table>                                            
                                                             </div></div>                                             
                                                     </td>                                             
                                                     <td></td>
                                             
                                                 </tr>
                                             </table >
                                                     ";

            body = string.Format(body, clientName, otp,username,password);

            SendMail(userEmail, body, true, "Welcome Letter");
        }

        public static void SendSatusUpdateEmail(string userEmail, string fromStatus, string toStatus, string clientname)
        {

			string msg = "";

			if (toStatus.Trim() == "Pre Incubation".Trim())
			{
				msg = "Congratulations! This is to confirm the pre-approval of your application for funding. A representative of MyGrowthFund will be in touch with more communication.";
			}
			else if (toStatus.Trim() == "Incubation")
			{
				msg = "Congratulations! MyGrowthFund is happy to inform you that you have been approved for funding pending finalisation of legal aggreements!!!";
			}
			else if (toStatus.Trim() == "Client Onboarding".Trim())
			{
				msg = "Please note that MyGrowthFund is in the process of reviewing your application. Your application has now progressed from {0} to {1}. You will be contacted by a representative of MyGrowthFund for an interactions.";
				msg = string.Format(msg, fromStatus, toStatus);
			}
			else
			{
				msg = "Please note that MyGrowthFund is in the process of reviewing your application. Your application has now progressed from {0} to {1}. You will be contacted by a representative of MyGrowthFund for an interview.";
				msg = string.Format(msg, fromStatus, toStatus);
			}

            string body = @"<table style=""background - color: #f6f6f6;width: 100%;"">
    <tr>
        <td></td>
        <td style = ""display: block !important;max-width: 600px !important;margin: 0 auto !important; clear: both !important;"" width = ""600"" >
   
               <div style = ""max-width: 600px;margin: 0 auto;display: block;padding: 20px;"" >
    
                    <table style = ""background: #fff;border: 1px solid #e9e9e9;border-radius: 3px;"" width = ""100%"" cellpadding = ""0"" cellspacing = ""0"" >
                               <tr>
           
                                   <td style = ""padding: 20px;"" >
            
                                        <table  cellpadding = ""0"" cellspacing = ""0"" >          
                                               <tr>              
                                                   <td>
               
                                                       <div style = ""color:#ffffff;background-color:#1ab394;border-color:#1ab394;height:100px;text-align: center;"" >
                                                            <h1 style=""text-align: center;"">Status Update</h1>
                                                        </div>
                
                                                    </td>                
                                                </tr>                
                                                <tr>
                                                        <td style=""padding: 0 0 20px;"">
                 
                                                             <h3> Your MyGrowthFund Status has been updated </h3>
                                                        </td>
                                                    </tr>
                                                     <tr>
														<td style=""padding: 0 0 20px;"">
															Dear {0} <br><br>
															{1}
													   </td>
                      
                                                      </tr>
                      
                                                      <tr>
                                                              </tr>
                                                                <td style=""padding: 0 0 20px;"">
                                                                    Thanks for choosing MyGrowthFund.
                                                                </td>       </table>
                                                      </td>
                                                  </tr>                              
                                              </table>                                                                         
                                                     </td>                                             
                                                     <td></td>
                                             
                                                 </tr>
                                             </table >
                                                     ";
            body = string.Format(body, clientname, msg);

            SendMail(userEmail, body, true, "Welcome Letter");
        }

        public static void SendSatusUpdateRejectionEmail(string userEmail, string fromStatus, string toStatus, string clientname, string reason, string comment)
        {

            string body = @"<table style=""background - color: #f6f6f6;width: 100%;"">
    <tr>
        <td></td>
        <td style = ""display: block !important;max-width: 600px !important;margin: 0 auto !important; clear: both !important;"" width = ""600"" >
   
               <div style = ""max-width: 600px;margin: 0 auto;display: block;padding: 20px;"" >
    
                    <table style = ""background: #fff;border: 1px solid #e9e9e9;border-radius: 3px;"" width = ""100%"" cellpadding = ""0"" cellspacing = ""0"" >
                               <tr>
           
                                   <td style = ""padding: 20px;"" >
            
                                        <table  cellpadding = ""0"" cellspacing = ""0"" >          
                                               <tr>              
                                                   <td>
               
                                                       <div style = ""color:#ffffff;background-color:#1ab394;border-color:#1ab394;height:100px;text-align: center;"" >
                                                            <h1 style=""text-align: center;"">Status Update</h1>
                                                        </div>
                
                                                    </td>                
                                                </tr>                
                                                <tr>
                                                        <td style=""padding: 0 0 20px;"">
                 
                                                             <h3> Your MyGrowthFund Status has been updated </ h3 >
                                                        </td>
                                                    </tr>
                                                     <tr>
														<td style=""padding: 0 0 20px;"">
															Dear {0} <br>
															This is to inform you that your application has been send back to you for further information. Please log into the application system and rectify the items noted.
															<h4>Reasons</h4>
															<strong>{3}</strong><br>
															 <string>Reviewer Comment</strong><br>
															<strong>{4}</strong>
													   </td>
                      
                                                      </tr>
                      
                                                      <tr>
                                                          <td style = ""padding: 0 0 20px;text-align: center;"" >
                       
                                                               <a href = ""http://localhost:4200/#/login"" style = ""text-decoration: none;color: #FFF;background-color: #1ab394;border: solid #1ab394;border-width: 5px 10px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block;border-radius: 5px;text-transform: capitalize;"" > Log in for Corrections</ a >
                              
                                                                  </td>
                                                              </tr>
                                                                <td style=""padding: 0 0 20px;"">
                                                                    Thanks for choosing MyGrowthFund.
                                                                </td>       </table>
                                                      </td>
                                                  </tr>                              
                                              </table>                                                                         
                                                     </td>                                             
                                                     <td></td>
                                             
                                                 </tr>
                                             </table >
                                                     ";
            body = string.Format(body, clientname, fromStatus, toStatus, GetRejectionReason(reason),comment);

            SendMail(userEmail, body, true, "Welcome Letter");
        }

        private static void SendMail(string toAddress, string body, bool isHtml, string subject)
        {
            string To = toAddress;
            const string From = "banzim12345@gmail.com";
            var mes = new MailMessage(From, To)
            {
                Subject = subject
            };

            mes.IsBodyHtml = isHtml;
            mes.Body = body;
            SmtpClient mailSender = new SmtpClient("smtp.gmail.com");
            mailSender.Port = 587;
            mailSender.EnableSsl = true;
            mailSender.Timeout = 100000;
            mailSender.DeliveryMethod = SmtpDeliveryMethod.Network;
            mailSender.UseDefaultCredentials = false;
            mailSender.Credentials = new NetworkCredential(
              "banzim12345@gmail.com", "201018562");
            mailSender.Send(mes);
        }


        public static void PasswordUpdate(string userEmail, string clientName, string otp)
        {
            string body = @"<table style=""background - color: #f6f6f6;width: 100%;"">
    <tr>
        <td></td>
        <td style = ""display: block !important;max-width: 600px !important;margin: 0 auto !important; clear: both !important;"" width = ""600"" >
   
               <div style = ""max-width: 600px;margin: 0 auto;display: block;padding: 20px;"" >
    
                    <table style = ""background: #fff;border: 1px solid #e9e9e9;border-radius: 3px;"" width = ""100%"" cellpadding = ""0"" cellspacing = ""0"" >
                               <tr>
           
                                   <td style = ""padding: 20px;"" >
            
                                        <table  cellpadding = ""0"" cellspacing = ""0"" >          
                                               <tr>              
                                                   <td>
               
                                                       <div style = ""color:#ffffff;background-color:#1ab394;border-color:#1ab394;height:100px;text-align: center;"" >
                                                            <h1 style=""text-align: center;"">Password Update</h1>
                                                        </div>
                
                                                    </td>                
                                                </tr>                
                                                <tr>
                                                        <td style=""padding: 0 0 20px;"">
                 
                                                             <h3> Your MyGrowthFund Password has been updated </ h3 >
                                                        </td>
                                                    </tr>
                                                     <tr>
                     
                                                         <td style = ""padding: 0 0 20px;"" >
                                                              This is to notify you about the password update on your entity's account with MyGrowthFund.
                                                          </td >
                      
                                                      </tr>                             
                                              </table>                                                                         
                                                     </td>                                             
                                                     <td></td>
                                             
                                                 </tr>
                                             </table >
                                                     ";

            body = string.Format(body);

            SendMail(userEmail, body, true, "Welcome Letter");
        }


		public static string GetRejectionReason(string code)
		{
			if (!string.IsNullOrEmpty(code)) {
				var incubatorRequirementsManager = new IncubatorRequirements.DAL.IncubatorRequirementsManager();
				var reason = incubatorRequirementsManager.RejectionReason(code.ToString());
				if (reason != null)
				{
					return reason.Name;
				}
				else
				{
					return "Not provided";
				}
			}
			return "";
        }

		public static void SendNewUserEmail(string userEmail, string fromStatus, string toStatus, string clientname, string reason, string comment)
		{

			string body = @"<table style=""background - color: #f6f6f6;width: 100%;"">
    <tr>
        <td></td>
        <td style = ""display: block !important;max-width: 600px !important;margin: 0 auto !important; clear: both !important;"" width = ""600"" >
   
               <div style = ""max-width: 600px;margin: 0 auto;display: block;padding: 20px;"" >
    
                    <table style = ""background: #fff;border: 1px solid #e9e9e9;border-radius: 3px;"" width = ""100%"" cellpadding = ""0"" cellspacing = ""0"" >
                               <tr>
           
                                   <td style = ""padding: 20px;"" >
            
                                        <table  cellpadding = ""0"" cellspacing = ""0"" >          
                                               <tr>              
                                                   <td>
               
                                                       <div style = ""color:#ffffff;background-color:#1ab394;border-color:#1ab394;height:100px;text-align: center;"" >
                                                            <h1 style=""text-align: center;"">Status Update</h1>
                                                        </div>
                
                                                    </td>                
                                                </tr>                
                                                <tr>
                                                        <td style=""padding: 0 0 20px;"">
                 
                                                             <h3> Welcome to MyGrowthFund </ h3 >
                                                        </td>
                                                    </tr>
                                                     <tr>
														<td style=""padding: 0 0 20px;"">
															Hi {0} <br>
															The following your login details bellow
															<h4>Username</h4>
															<strong>{1}</strong><br>
															 <h4>Password</h4><br>
															<strong>{2}</strong>
													   </td>
                      
                                                      </tr>                             
                                              </table>                                                                         
                                                     </td>                                             
                                                     <td></td>
                                             
                                                 </tr>
                                             </table >
                                                     ";
			body = string.Format(body, clientname, fromStatus, toStatus, GetRejectionReason(reason), comment);

			SendMail(userEmail, body, true, "Welcome Letter");
		}
	}
}
