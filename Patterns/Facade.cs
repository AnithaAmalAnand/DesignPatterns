using System;
using Microsoft.Extensions.Logging;
using DesignPatterns.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using DesignPatterns.Models;

namespace DesignPatterns {
    
    
    public class FacadeService: IFacadeService {      
        public readonly IAccountProcessor _accountProcessor;
        public readonly IUserProcessor _userProcessor;
        public FacadeService(IAccountProcessor accountProcessor, IUserProcessor userProcessor) {
            _accountProcessor = accountProcessor;
            _userProcessor = userProcessor;

        }

        public async Task<bool> Process() {
            await _accountProcessor.GetRecords<int>();
            await _userProcessor.GetUser();
            return true;
        }
    }

    public class AccountProcessor: IAccountProcessor {
        public async Task<List<T>> GetRecords<T>() {
            var acctList = new List<T>();
            return acctList;

        }

    }

    public class UserProcessor: IUserProcessor {
        public async Task<User> GetUser() {        
            var user = new User();
            return user;
        }
    }
}