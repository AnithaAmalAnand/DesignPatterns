using System;
using Microsoft.Extensions.Logging;
using DesignPatterns.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using DesignPatterns.Models;

namespace DesignPatterns {
    
    
    public class FacadeService: IFacadeService {      
        
        private readonly IAccountProcessor _accountProcessor;
        private readonly IUserProcessor _userProcessor;
        public FacadeService( IAccountProcessor accountProcessor, IUserProcessor userProcessor) {
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
        private readonly ILogger _logger;
        public AccountProcessor(ILoggerFactory loggerFactory) {
            _logger = loggerFactory.CreateLogger<AccountProcessor>();

        }
        public async Task<List<T>> GetRecords<T>() {
            var acctList = new List<T>();
            _logger.LogDebug("`Creating a list");
            return acctList;

        }

    }

    public class UserProcessor: IUserProcessor {

        private readonly ILogger _logger;
        public UserProcessor(ILoggerFactory loggerFactory) {
            _logger = loggerFactory.CreateLogger<UserProcessor>();
        }
        public async Task<User> GetUser() {        
            var user = new User();
            _logger.LogDebug("`Creating an user object");
            return user;
        }
    }
}