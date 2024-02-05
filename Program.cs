global using System;
using Telegram.Bot;
using System.Xml.Serialization;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading;

namespace consoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("5825963097:AAGjH4DLcO14SxgynOH8PBFJoZ_YkckZpuw");
            client.StartReceiving(Update, Error); // ctrl + shift + пробел
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            var username = message.From.FirstName;
            if (message.Text != null)
            {
                await botClient.SendTextMessageAsync(
                    message.Chat.Id, $"Привет {username}!\nПереходи по ссылке, чтобы получить доступ к каналу!",
                    replyMarkup: new InlineKeyboardMarkup(
                        InlineKeyboardButton.WithUrl(
                            text:"Ссылка",
                            url: "https://t.me/+cLqujfuN2lY5NTQy"
                            )
                    ));
                Console.WriteLine($"{message.Chat.Username}     |     {message.Text}");

                return;
            }
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}


