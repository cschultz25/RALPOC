﻿using Backend.DataObjects;
using Backend.Extensions;
using Backend.Models;
using Microsoft.Azure.Mobile.Server;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Backend.Controllers
{
    public class MessageController : TableController<Message>
    {
        private MobileServiceContext context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Message>(context, Request);
        }

        public string UserId => ((ClaimsPrincipal)User).FindFirst(ClaimTypes.NameIdentifier).Value;

        // GET tables/Message
        [ExpandProperty("tags")]
        public IQueryable<Message> GetAllMessage()
        {
            return Query();
            //return Query().OwnedByFriends(context.Friends, UserId);
        }

        // GET tables/Message/48D68C86-6EA6-4C25-AA33-223FC9A27959
        [ExpandProperty("tags")]
        public SingleResult<Message> GetMessage(string id)
        {
            return new SingleResult<Message>(Lookup(id).Queryable);
            //return new SingleResult<Message>(Lookup(id).Queryable.OwnedByFriends(context.Friends, UserId));
        }

        // POST tables/Message
        public async Task<IHttpActionResult> PostMessageAsync(Message item)
        {
            item.UserId = UserId;
            Message current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }
    }
}