using Santa_Final_ASP.Models.Contexts;
using Santa_Final_ASP.Models.Entities;
using Santa_Final_ASP.Models.Identity;
using Santa_Final_ASP.ViewModels;
using Microsoft.EntityFrameworkCore;
using Azure.Messaging;

namespace Santa_Final_ASP.Services;

public class MessageService
{
    private readonly MessageContext _messageContext;

    public MessageService(MessageContext messageContext)
    {
        _messageContext = messageContext;
    }


    //Saves a message and their info
    public async Task<bool> RegisterMessageAsync(ContactFormViewModel viewModel)
    {
        try
        {
            //Gets info from contact form
            ContactMessage _contactMessage = viewModel;
            MessageUser _messageUser = viewModel;

            if (_contactMessage.SaveEmail == false)
            {
                // If they dont want info saved, overwrites info with "Unknown"
                _contactMessage.MessageInfo = new MessageUser
                {
                    Email = "Unknown",
                    Nickname = "Unknown",
                    PhoneNumber = "Unknown",
                    Company = "Unknown",
                };

                // Checks if there already exists incognito info in db
                var _incognitoUser = await _messageContext.MessageInfos.FirstOrDefaultAsync(x => x.Email == _contactMessage.MessageInfo.Email && x.Nickname == _contactMessage.MessageInfo.Nickname);

                // Sets old incognito info to new message
                if (_incognitoUser != null)
                {
                    _contactMessage.MessageInfo = _incognitoUser;
                }

            }
            else
            {
                //Checks if there is info for a person already
                var _messageInfo = await _messageContext.MessageInfos.FirstOrDefaultAsync(x => x.Email == viewModel.Email && x.Nickname == viewModel.Name);
                if (_messageInfo == null)
                {
                    //Sets new data for a persons info
                    _contactMessage.MessageInfo = new MessageUser
                    {
                        Email = _messageUser.Email,
                        Nickname = _messageUser.Nickname,
                        PhoneNumber = _messageUser.PhoneNumber,
                        Company = _messageUser.Company,
                    };

                }
                else
                {
                    //Sets old info to message from db, (the person has messageed before)
                    _contactMessage.MessageInfo = _messageInfo;

                }
            }


            //Adds info to message, and adds new row to db
            _messageContext.Add(new ContactMessage
            {
                Message = _contactMessage.Message,
                SaveEmail = _contactMessage.SaveEmail,
                MessageInfo = _contactMessage.MessageInfo,
            });

            // Saves changes to user
            await _messageContext.SaveChangesAsync();

            return true;
        }
        catch
        {
            return false;
        }
    }
}
