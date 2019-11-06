using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel
{
    public class QuestionsModel
    {
        public int ID { get; set; } //Konu Başlığı
        public string Topic { get; set; } //Konu Başlığı
        public string Ask { get; set; } //Gelen Veri Soru Metni
        public string Description { get; set; } //Gönderilen Veri Soru Metni


        /* SORU DEĞİŞKENLERİ */
        public string Questions1 { get; set; }
        public string Questions2 { get; set; }
        public string Questions3 { get; set; }
        public string Questions4 { get; set; }

        /* ŞIK DEĞİŞKENLERİ */
        public string ReplyA1 { get; set; }
        public string ReplyA2 { get; set; }
        public string ReplyA3 { get; set; }
        public string ReplyA4 { get; set; }

        public string ReplyB1 { get; set; }
        public string ReplyB2 { get; set; }
        public string ReplyB3 { get; set; }
        public string ReplyB4 { get; set; }

        public string ReplyC1 { get; set; }
        public string ReplyC2 { get; set; }
        public string ReplyC3 { get; set; }
        public string ReplyC4 { get; set; }

        public string ReplyD1 { get; set; }
        public string ReplyD2 { get; set; }
        public string ReplyD3 { get; set; }
        public string ReplyD4 { get; set; }

        /* DOĞRU CEVAP DEĞİŞKENLERİ */
        public string TrueReply1 { get; set; }
        public string TrueReply2 { get; set; }
        public string TrueReply3 { get; set; }
        public string TrueReply4 { get; set; }

        public DateTime InsertedDate { get; set; }
    }
}
