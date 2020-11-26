using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class SendMailScript : MonoBehaviour
{
    /*
    This docuent purpos is to send mail from the death scen.
    General construktion is that the the buttons is triggering send() and taking gmail acound from an textinput
    This might need som moore testing so it work propely.*/
    public InputField sendto, useraccount, password;
    string message, subject, gmail, password2;

    public void setpassword(string inputpassword, string inputgmail){
        password2 = inputpassword;
        gmail = inputgmail;
    }

    public void setmessage(){
        int wavedpassd   = PlayerPrefs.GetInt("HighscoreWavepassed");
        int lvl          = PlayerPrefs.GetInt("HighscoreCurrentLVL");
        string Mapname   = PlayerPrefs.GetString("HigscoreMapname");

        message = "Take a look at my impressiv score in return to castle zombie." + " wavedpassd: " + wavedpassd.ToString() + " lvl: " + lvl.ToString() + " Mapname: " + Mapname;
        subject = "Look at my impressiv highscore in Return of castle zombie" + useraccount.text;
    }

    public void send(){
        setpassword(password.text, useraccount.text);
        setmessage();

        MailMessage mail    = new MailMessage();
	
        mail.From           = new MailAddress(gmail);
        mail.To.Add(sendto.text);

        mail.Subject        = "Return of castle defence";
        mail.Body           = message;

        try{
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential(gmail, password2) as ICredentialsByHost;
            smtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = 
            delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
                { return true; };

            smtpServer.Send(mail);

            Debug.Log("Success, Email has been sent!!!");
        }
        catch {
            Debug.Log("Faild to send mail");
        }
    }
}
