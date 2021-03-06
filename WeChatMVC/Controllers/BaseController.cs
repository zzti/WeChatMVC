﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Web.Mvc;
using Aliyun.MNS.Model;

namespace WeChatMVC.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public static string MD5Encrypter(string input, string state)
        {
            string token = "E58D8EE79086E9809AE5BEAEE4BFA1";
            DateTime now = DateTime.Now;
            string date = now.Year.ToString() + now.Month.ToString() + now.Day.ToString();
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytesinput = Encoding.UTF8.GetBytes(input + token + date + state);
            byte[] bytesoutput = md5.ComputeHash(bytesinput);

            string output = "";
            for (int i = 0; i < bytesoutput.Length; i++)
            {
                output += bytesoutput[i].ToString("x2");
            }
            return output;
        } //通用MD5加密
        public void SendSMS(string telenum)
        {
            string _endpoint = "https://1076168149508929.mns.cn-shenzhen.aliyuncs.com/"; // eg. http://1234567890123456.mns.cn-shenzhen.aliyuncs.com
            string _accessKeyId = "LTAI9KVo5A2RNmaQ";
            string _secretAccessKey = "Ok64W1hAs6tPs3FUC6pOWjnqApvPhW";
            string _topicName = "printer";
            string _freesignname = "410打印店";
            string _templatecode = "SMS_67201137";
            Aliyun.MNS.IMNS client = new Aliyun.MNS.MNSClient(_accessKeyId, _secretAccessKey, _endpoint);
            Aliyun.MNS.Topic topic = client.GetNativeTopic(_topicName);
            BatchSmsAttributes batchsmsattributes = new BatchSmsAttributes();
            MessageAttributes messageattributes = new MessageAttributes();

            batchsmsattributes.FreeSignName = _freesignname;
            batchsmsattributes.TemplateCode = _templatecode;
            Dictionary<string, string> param = new Dictionary<string, string>();

            batchsmsattributes.AddReceiver(telenum, param);
            messageattributes.BatchSmsAttributes = batchsmsattributes;

            PublishMessageRequest request = new PublishMessageRequest();
            request.MessageAttributes = messageattributes;

            request.MessageBody = "not null";

            try
            {
                PublishMessageResponse resp = topic.PublishMessage(request);
            }
            catch
            {
            }
        }//发送短信通知
        public string Welcome()
        {
            return "Don't touch this server,guy";
        }
    }
}