using Repository_Pattern.Repository;

namespace Repository_Pattern.Service
{
    public class HomeService : IHomeService
    {
        public HomeService(
            IBookRepository bookRepository,
            ICourseRepository courseRepository,
            IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        #region Private Property

        private IBookRepository _bookRepository { get; }

        private ICourseRepository _courseRepository { get; }

        private IUnitOfWork _unitOfWork { get; }

        #endregion Private Property

        public string Get()
        {
            return _bookRepository.Get(1).Title;
        }
    }
}