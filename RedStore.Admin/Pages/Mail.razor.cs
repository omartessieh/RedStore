using Microsoft.AspNetCore.Components;
using RedStore.Admin.Interfaces;
using RedStore.Models.Dtos;

namespace RedStore.Admin.Pages
{
    public partial class Mail : ComponentBase
    {
        [Inject]
        public IAdminService AdminService { get; set; }

        public IEnumerable<ContactDto> GetContacts { get; set; }

        bool fixed_header = true;

        bool fixed_footer = false;

        private string _searchString;

        private bool _sortNameByLength;

        public string PopSubject;

        public string PopMessage;

        public bool _isOpen = false;

        protected override async Task OnInitializedAsync()
        {
            GetContacts = await AdminService.GetContacts();
            GetContacts = GetContacts.OrderByDescending(x => x.Created_at);
        }

        private Func<ContactDto, object> _sortBy => x =>
        {
            if (_sortNameByLength)
                return x.Subject.Length;
            else
                return x.Subject;
        };

        private Func<ContactDto, bool> _quickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            if (x.Username.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Email.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Subject.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.Created_at}".Contains(_searchString))
                return true;

            return false;
        };

        private void OpenMessage(string Message, string Subject)
        {
            if (_isOpen)
            {
                _isOpen = false;
            }
            else
            {
                _isOpen = true;
                PopSubject = Subject;
                PopMessage = Message;
            }
        }

        private void Open()
        {
            if (_isOpen)
            {
                _isOpen = false;
            }
            else
            {
                _isOpen = true;
            }
        }

    }
}