using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T> //Generic olareak T datası alacak
    {
        public T Data { get; set; }
        [JsonIgnore] //seri hale getirmek için bir tür gösterilmektedir. Ayrıca JSON çıkışını da gösterir
        public int StatusCode { get; set; } // postmandeki mantık
        public List<String> Errors { get; set; }
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data,StatusCode = statusCode};
        }
        public static CustomResponseDto<T> Success(int statusCode) // update için data geri döndürmeye gerekyok sadece durum codu göndereck 
        {
            return new CustomResponseDto<T> {  StatusCode = statusCode };
        }
        public static CustomResponseDto<T> Fail(int statusCode,List<string> errors) // başarısız olma durumunda
        {
            return new CustomResponseDto<T> { StatusCode = statusCode,Errors=errors };
        }
        public static CustomResponseDto<T> Fail(int statusCode, string error) // bir tane hatta geldiğinde bu çalışacak
        {
            return new CustomResponseDto<T> {StatusCode = statusCode, Errors=new List<string> { error } };
        }
    }
}
