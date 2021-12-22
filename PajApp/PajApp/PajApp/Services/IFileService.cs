using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PajApp.Services
{
    /// <summary>
    /// Using this interface i tried to solve problem of saving files on different platforms. For now useless until i implement it in platform projects
    /// </summary>
    public interface IFileService
    {
        Task WriteTextAsync(string name, string content);
    }
}
