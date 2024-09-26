using AutoMapper;
using Library.Dto;
using Library.Model;
using Library.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        private readonly IMapper _mapper;

        private readonly ResponseDto _responseDto;
        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto>> AddBlog(BookDto book)
        {
            Console.WriteLine(book);
            //Map it to blog
           Book newBook = _mapper.Map<Book>(book);
            string resp = await _bookService.CreateBook(newBook);
            
            if(resp == "success")
            {
            _responseDto.Message = resp;
            _responseDto.Result = newBook;
            _responseDto.statusCode = HttpStatusCode.OK;
                return Ok(_responseDto);
            }
            else
            {
                _responseDto.Message = resp;
                _responseDto.Result = newBook;
                _responseDto.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_responseDto);
            }

        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseDto>>> GetAllBlogs()
        {
            try
            {
                var books = await _bookService.GetBooks();

                _responseDto.Message = "All Books";
                _responseDto.Result = books;
                _responseDto.statusCode = HttpStatusCode.OK;

                return Ok(_responseDto);
            }
            catch(Exception e)
            {
                _responseDto.Message = $"Something went very wrong: {e.InnerException}";
                return NotFound(_responseDto);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto>> GetABook(Guid id)
        {
            try
            {
                Book book = await _bookService.GetOneBook(id);
                _responseDto.Message = "Book";
                _responseDto.Result = book;
                _responseDto.statusCode= HttpStatusCode.OK;
                return Ok(_responseDto);
            }
            catch(Exception ex)
            {
                _responseDto.Message = $"Failure {ex.InnerException}";
                return NotFound(_responseDto);
            }         
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto>> UpdateBook(Guid id, BookDto book)
        {
            try
            {
                 Book oneBook = await _bookService.GetOneBook(id);
                if(oneBook != null)
                {
                    var newBook = _mapper.Map(book, oneBook);
                    string resp =await  _bookService.updateBook(newBook);
                    _responseDto.Message = resp;
                    _responseDto.Result = newBook;
                    return Ok(_responseDto);
                }
                _responseDto.Message = "Not found";
                return BadRequest(_responseDto);
            }
            catch(Exception ex)
            {
                _responseDto.Message = $"failure {ex.InnerException}";
                return BadRequest(_responseDto);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto>> DeleteProduct(Guid id)
        {
            try
            {
                Book oneBook = await  _bookService.GetOneBook(id); 
                if( oneBook != null )
                {
                var bookDlt = _mapper.Map<Book>(oneBook);
                string resp = await  _bookService.DeleteBook(bookDlt);
                _responseDto.Message = resp;
                _responseDto.Result = null;
                _responseDto.statusCode = HttpStatusCode.NoContent;
                return Ok(_responseDto);
                }
                _responseDto.Message = "Not Found";
                _responseDto.statusCode = HttpStatusCode.NotFound;
                return BadRequest(_responseDto);
            }
            catch (Exception ex)
            {
                _responseDto.Message = $" Something is wrong {ex.InnerException}";
                return BadRequest(_responseDto);
            }
        }
    }
}
