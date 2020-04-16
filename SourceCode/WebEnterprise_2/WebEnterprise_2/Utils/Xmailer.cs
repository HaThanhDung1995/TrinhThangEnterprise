﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;

namespace WebEnterprise_2.Utils
{
    public class Xmailer
    {
        /// <summary>
        /// Gửi email
        /// </summary>
        /// <param name="To">Email người nhận</param>
        /// <param name="Subject">Tiêu đề email</param>
        /// <param name="Body">Nội dung email</param>
        /// <param name="Others">
        /// Các thông số khác theo thứ tự sau:
        /// FROM: Email người gửi
        /// CC: Danh sách email những người cùng nhận công khai. Các email các nhau dấu phẩy hoặc chấm phẩy
        /// BCC: Danh sách email những người cùng nhận bí mật. Các email các nhau dấu phẩy hoặc chấm phẩy
        /// FILE: Danh sách đường dẫn file đính kèm. Các đường dẫn cách nhau dấu phẩy hoặc chấm phẩy
        /// </param>
        public static void Send(List<string> To, string Subject, string Body, params string[] Others)
        {
            // Tạo thư
//            MailMessage mail = new MailMessage();
//            mail.To.Add(To);
//            mail.Subject = Subject;
//            mail.Body = Body;
//            mail.IsBodyHtml = true;
//            
//            if (Others.Length > 0 && !String.IsNullOrEmpty(Others[0]))
//            {
//                mail.From = new MailAddress(Others[0], Others[0]);
//            }
//            else
//            {
//                mail.From = new MailAddress("daotao@nhatnghe.com", "FeedBack");
//            }
//            mail.ReplyToList.Add(mail.From);
//            if (Others.Length > 1 && !String.IsNullOrEmpty(Others[1]))
//            {
//                mail.CC.Add(Others[1].Trim().Replace(';', ','));
//            }
//            if (Others.Length > 2 && !String.IsNullOrEmpty(Others[2]))
//            {
//                mail.Bcc.Add(Others[2].Trim().Replace(';', ','));
//            }
//            if (Others.Length > 3 && !String.IsNullOrEmpty(Others[3]))
//            {
//                String[] fileNames = Others[3].Split(';', ',');
//                foreach (var fileName in fileNames)
//                {
//                    mail.Attachments.Add(new Attachment(fileName));
//                }
//            }
//
//            // Kết nối bưu điện
//            var smtp = new SmtpClient("smtp.gmail.com", 465)
//            {
//                EnableSsl = true,
//                Credentials = new NetworkCredential("hathanhdung1995@gmail.com", "123a123@"),
//                
//            };

             //Gửi thư
            //smtp.Send(mail);
            
            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 25;
            WebMail.SmtpUseDefaultCredentials = true;
            WebMail.EnableSsl = true;
            WebMail.UserName = "vinhnnse61927@gmail.com";
            WebMail.Password = "syndicatenoemotioN2#@";
           
            foreach (var item in To )
            {
                WebMail.Send(to: item, subject: Subject, body: Body, isBodyHtml: true);
            }
        }
    }
}