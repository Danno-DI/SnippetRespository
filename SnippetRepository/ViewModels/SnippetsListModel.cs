using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Collections.Generic;
using System.ServiceModel.DomainServices.Client;
using SnippetRepository.Web.Services;

namespace SnippetRepository.ViewModels
{
    public class SnippetsListModel : BindableObject
    {

        private readonly SnippetRepositoryDomainContext _context;
        private bool _isLoading;

        public SnippetsListModel()
        {
            _context = new SnippetRepositoryDomainContext();
            _isLoading = true;
            Snippets = _context.Snippets;

            if (!DesignerProperties.IsInDesignTool)
            {
                var loadOperation = _context.Load(_context.GetSnippetsQuery());
                loadOperation.Completed += loadOperation_Completed;
            }
        }

        private void loadOperation_Completed(object sender, EventArgs e)
        {
            _isLoading = false;                      
            RaisePropertyChanged("IsLoading");
        }

        public IEnumerable<Snippet> Snippets { get; set; }

        public bool IsLoading
        {
            get { return _isLoading; }
        }

        public void EditSnippetsList()
        {
            //var editWindow = new SnippetsLisEditWindow(CreateEditModel());
            //editWindow.Show();
        }

        public void NewSnippetsList()
        {
            //var newWindow = new SnippetsLisEditWindow(CreateNewModel());
            //newWindow.Show();
        }

        //public SnippetsListEditTask CreateEditModel()
        //{
        //    if (SelectedSnippetsLis != null)
        //    {
        //        return new SnippetsLisEditTask(SelectedSnippetsLis, _context.ForeignKeyEntity);
        //    }
        //    return null;
        //}

        //public SnippetsLisEditTask CreateNewModel()
        //{
        //    var model = new SnippetsLis();
        //    var windowModel = new SnippetsLisEditTask(model, _context.ForeignKeyEntity);
        //    windowModel.Completed += (s, e) =>
        //                                 {
        //                                     if (windowModel.IsCommitted)
        //                                     {
        //                                         _context.SnippetsLiss.
        //                                         Add(model);
        //                                         SelectedSnippetsLis = model;
        //                                     }
        //                                 };
        //    return windowModel;
        //}

        //public SnippetsLis SelectedSnippetsLis
        //{
        //    get { return _selectedSnippetsLis; }
        //    set
        //    {
        //        _selectedSnippetsLis = value;
        //        RaisePropertyChanged("SelectedSnippetsLis");
        //    }
        //}

        public void SaveSnippetsList()
        {
            _context.SubmitChanges(delegate(SubmitOperation operation)
                                       {
                                           if (operation.HasError)
                                           {
                                               MessageBox.Show("There was an error saving one or more changes. Please check the marked errors.");
                                               operation.MarkErrorAsHandled();
                                           }
                                       }, null);
        }
    }
}
