using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using ToDoList.Domain.Enum;
using ToDoListDomain.Enum;

namespace TelegramBot
{
    public class TelegramClass
    {
        public static string _NameTask;
        public static Priority  _Priority;
        public static Curator _Curator;
        public static int message_selector;
        public static string _desc;
        static string WhoMustToDo(Curator curator)
        {
            if (curator == Curator.Ann)
            {
                return "Ответственная жена";
            }
            else
            {
                return "Отвественный муж";
            }
        }
        static string WhoDidTask(Curator curator)
        {
            if (curator == Curator.Ann)
            {
                return "Жена выполнила задачу";
            }
            else
            {
                return "Муж выполнил задачу";
            }
        }
        static string WhenYouShoudDo(Priority priority)
        {
            if(priority == Priority.Easy)
            {
                return "Может подождать";
            }
            else
            {
                return "Откладывать нельзя!";
            }
        }

        //static string _Curator;
        public static async Task Main()
        {
            string[] id = new string[] { "269868158", "249153783" };
            string priority_message = WhenYouShoudDo(_Priority);
            string curator_message = WhoDidTask(_Curator);
            string duty_message = WhoMustToDo(_Curator);
            TelegramBotClient botClient = new TelegramBotClient("6381161824:AAEC7AKSQp6-rG2gJwoJ6W-pa_Xbg_ij5tE");
            if(message_selector == 1)
            {
                foreach(var item in id)
                {
                    await botClient.SendTextMessageAsync(chatId: item,
                text: $"Поставлена задача - {_NameTask}\nВажность - {priority_message}\n{duty_message}\nОписание - {_desc}\nhttp://pavelannataskmanager.somee.com/");
                }
                

            }
            else if(message_selector == 2)
            {
                foreach (var item in id)
                {
                    await botClient.SendTextMessageAsync(chatId: item,
                text: $"{curator_message} - {_NameTask}\nhttp://pavelannataskmanager.somee.com/");
                }    
                    
            }
            else if (message_selector == 3)
            {
                foreach (var item in id)
                {
                    await botClient.SendTextMessageAsync(chatId: item,
                text: $"Задача ({_NameTask}) обновлена!\nhttp://pavelannataskmanager.somee.com/");
                }
                    
            }
            else if (message_selector == 4)
            {
                foreach (var item in id)
                {
                    await botClient.SendTextMessageAsync(chatId: item,
                text: $"Задача ({_NameTask}) удалена!\nhttp://pavelannataskmanager.somee.com/");
                }                   
            }
        }

    }
}
