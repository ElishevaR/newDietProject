using Azure;
using Core.Models;
using Core.Models.Responses;
using Data.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class SubscriberRepository : ISubscriberRepository
    {
        readonly DataContext _DataContext;
        public SubscriberRepository(DataContext dataContext)
        {
            _DataContext = dataContext;
        }
        public async Task<BasicResponse<bool>> AddSubscriber(Subscriber subscriber,float height)
        {
            BasicResponse<bool> basicResponse = new BasicResponse<bool>();
            Exception e = new Exception("");
            if (_DataContext.Subscribers.Where(t => t.Email == subscriber.Email).FirstOrDefault() != null)
                throw new MyException(204, "Subscriber already exists!", e.Message);
            try
            {
                basicResponse.response = true;
                basicResponse.succeed = true;
                //var card = new Card { Height = height,updateDate=DateTime.Today, OpenDate=DateTime.Today,Bmi=0,SubscriberId=subscriber.Id};
                _DataContext.Add(subscriber);
                //_DataContext.Cards.Add(card);
                await _DataContext.SaveChangesAsync();
                basicResponse.succeed=true;
            }
            catch (Exception ex)
            {
                basicResponse.response = false;
                throw new MyException(204, "Subscriber already exists!", ex.Message);
            }
            return basicResponse;
        }
        public async Task<BasicResponse<int>> Login(string password, string email)
        {
            BasicResponse<int> basicResponse = new BasicResponse<int>();

            try
            {
                Subscriber s = _DataContext.Subscribers.Where(t => t.Password == password && t.Email == email).FirstOrDefault();

              //  Subscriber s = await _DataContext.Subscribers.Where(t => t.Password == password && t.Email == email).FirstOrDefaultAsync();
                basicResponse.succeed= true;
                basicResponse.response = s.Id;

            }
            catch (Exception ex)
            {
                throw new MyException(204, "Password and Email are not exist!", ex.Message);

            }
            return basicResponse;
        }
        public async Task<BasicResponse<SubscriberAndCardResponse>> GetCard(int id)
        {
            BasicResponse<SubscriberAndCardResponse> basicResponse = new BasicResponse<SubscriberAndCardResponse>() { };

            try
            {
                //Subscriber s = await _DataContext.Subscribers.Where(t => t.Id == id).FirstOrDefaultAsync();
                //Card c =  await _DataContext.Cards.Where(t => t.SubscriberId == s.Id).FirstOrDefaultAsync();

                Subscriber s =  _DataContext.Subscribers.Where(t => t.Id == id).FirstOrDefault();
                Card c = _DataContext.Cards.Where(t => t.SubscriberId == s.Id).FirstOrDefault();
                SubscriberAndCardResponse subscriberAndCard = new SubscriberAndCardResponse() 
                { BMI = c.Bmi, FirstName = s.FirstName, Height = c.Height, LastName = s.LastName, SubscriberId = s.Id, Weight = c.Weight };
                basicResponse.succeed = true;
                basicResponse.response = subscriberAndCard;
                return basicResponse;
            }
            catch (Exception ex)
            {

                throw new MyException(204, "Fail!", ex.Message);
            }


        }
        //public async Task<bool> GetSubscriberByPassword(string password)
        //{
        //    try
        //    {
        //        if (await _DataContext.Subscribers.Where(t => t.Password == password).FirstOrDefaultAsync() == null)
        //            return false;
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new MyException(204, "Passord isnt exist!", ex.Message);

        //    }


        //}//just for help

    }
}
