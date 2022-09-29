﻿using Amazon.S3.Model;
using Entities;
using P2P.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace P2P.Services
{
    public interface IAWSS3FileService
    {
        Task<bool> UploadFile(AWSFileUpload files);
        Task<List<string>> FilesList();
        Task<List<string>> FilesListSearch(string fileName);
        Task<Stream> GetFile(string key);
        // Task<bool> UpdateFile(UploadFileName uploadFileName, string key);
        Task<bool> DeleteFile(string key);
    }
    public class AWSS3FileService : IAWSS3FileService
    {
        private readonly IAWSS3BucketHelper _AWSS3BucketHelper;

        public AWSS3FileService(IAWSS3BucketHelper AWSS3BucketHelper)
        {
            this._AWSS3BucketHelper = AWSS3BucketHelper;
        }
        public async Task<bool> UploadFile(AWSFileUpload files)
        {
            byte[] fileBytes;
            if (files.Attachments.Count == 0) return false;
            foreach (var file in files.Attachments)
            {

                if (file.Length > 0)
                {
                    string imageName = file.FileName;
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                    try
                    {
                        Stream stream = new MemoryStream(fileBytes);
                        await _AWSS3BucketHelper.UploadFile(stream, imageName);
                        //File.WriteAllBytes(imgPath, fileBytes);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw e;
                        //return false;
                    }
                }

                //return true;
            }
            return true;
        }
        public async Task<List<string>> FilesList()
        {
            try
            {
                ListVersionsResponse listVersions = await _AWSS3BucketHelper.FilesList();
                return listVersions.Versions.Select(c => new { c.LastModified, c.Key }).OrderByDescending(e => e.LastModified)
                    .Select(e => e.Key).Take(60).ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<string>> FilesListSearch(string fileName)
        {
            try
            {
                return await _AWSS3BucketHelper.FilesListSearch(fileName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<Stream> GetFile(string key)
        {
            try
            {
                Stream fileStream = await _AWSS3BucketHelper.GetFile(key);
                if (fileStream == null)
                {
                    Exception ex = new Exception("File Not Found");
                    throw ex;
                }
                else
                {
                    return fileStream;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public async Task<bool> UpdateFile(UploadFileName uploadFileName, string key)
        //{
        //    try
        //    {
        //        var path = Path.Combine("Files", uploadFileName.ToString() + ".png");
        //        using (FileStream fsSource = new FileStream(path, FileMode.Open, FileAccess.Read))
        //        {
        //            return await _AWSS3BucketHelper.UploadFile(fsSource, key);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public async Task<bool> DeleteFile(string key)
        {
            try
            {
                return await _AWSS3BucketHelper.DeleteFile(key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
