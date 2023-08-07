using CoreMVC.Models;
using CoreMVC.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVC.Controllers
{
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //[HttpGet]
        [HttpGet("")]
        public List<Book> GetAllBooks()
        {
            ResponseModel<List<Book>> res = new ResponseModel<List<Book>>();
            try {
                res = _bookRepository.GetBooks();
                if(res.status)
                {
                    return res.data;
                } else
                {
                    Console.WriteLine(">>>>> "+res.message);
                }
            } catch (Exception ex) {
                Console.WriteLine(">>>>> "+ex.StackTrace);
                Console.WriteLine(">>>>> "+res.message);
            }
            return null;
        }

        //[HttpGet("{id}")]
        [HttpGet("{id:int:min(1)}")]
        public Book GetBook(int id)
        {
            ResponseModel<Book> res = new ResponseModel<Book>();
            try
            {
                res = _bookRepository.GetBook(id);
                if (res.status)
                {
                    return res.data;
                }
                else
                {
                    Console.WriteLine(">>>>> " + res.message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>>>> " + ex.StackTrace);
                Console.WriteLine(">>>>> " + res.message);
            }
            return null;
        }

        //[HttpGet("{title:alpha}/{author}")]
        [HttpGet("{value:alpha}")]
        public List<Book> SearchBook(string value)
        {
            ResponseModel<List<Book>> res = new ResponseModel<List<Book>>();
            try
            {
                res = _bookRepository.searchBooks(value);
                if (res.status)
                {
                    return res.data;
                }
                else
                {
                    Console.WriteLine(">>>>> " + res.message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>>>> " + ex.StackTrace);
                Console.WriteLine(">>>>> " + res.message);
            }
            return null;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
