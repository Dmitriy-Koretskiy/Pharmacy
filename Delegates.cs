using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy.Repositories;
using Pharmacy.Helpers;
using System.Data.Entity;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;

namespace Pharmacy
{
    public class Delegates
    {
        public delegate void HelperDelegate(Helper helper);

        public Dictionary<string, HelperDelegate> AddUniversal = new Dictionary<string, HelperDelegate> {
            { "Client", (helper) => 
                   helper.AddClient()
            },           
            { "FarmGroup", (helper) => 
                   helper.AddFarmGroup()
            },
            { "Medicine", (helper) => 
                   helper.AddMedicine()
            },
            { "ReleaseForm", (helper) => 
                   helper.AddReleaseForm()
            },
            { "Request", (helper) => 
                   helper.AddRequest()
            }
        };

        public delegate void DGridAndRepDelegate(DataGrid datagrid, IRepository repository);

        public Dictionary<string, DGridAndRepDelegate> FillFromTable = new Dictionary<string, DGridAndRepDelegate> {
            { "Client", (datagrid, repository) => 
                  datagrid.ItemsSource = repository.Clients
            },           
            { "FarmGroup", (datagrid, repository) => 
                  datagrid.ItemsSource = repository.FarmGroups
            }, 
            { "Medicine", (datagrid, repository) => 
                  datagrid.ItemsSource = repository.Medicines
            }, 
            { "ReleaseForm", (datagrid, repository) => 
                  datagrid.ItemsSource = repository.ReleaseForms
            }, 
            { "Request", (datagrid, repository) => 
                  datagrid.ItemsSource = repository.Requests
            }
        };
        public delegate void DGridAndHelpDelegate(DataGrid datagrid, Helper helper);

        public Dictionary<string, DGridAndHelpDelegate> DeleteUniversal = new Dictionary<string, DGridAndHelpDelegate> {
            { "Client", (datagrid, helper) => {
                Client client = (Client)datagrid.SelectedItem;
                int id = client.Id;
                helper.DeleteClient(id);
                }                        
            },
            { "FarmGroup", (datagrid, helper) => {
                   FarmGroup item = (FarmGroup)datagrid.SelectedItem;
                   int id = item.Id;
                   helper.DeleteFarmGroup(id);
                }                        
            },
            { "Medicine", (datagrid, helper) => {
                   Medicine item = (Medicine)datagrid.SelectedItem;
                   int id = item.Id;
                   helper.DeleteMedicine(id);
                }                        
            },
            { "ReleaseForm", (datagrid, helper) => {
                   ReleaseForm item = (ReleaseForm)datagrid.SelectedItem;
                   int id = item.Id;
                   helper.DeleteReleaseForm(id);
                }                        
            },
            { "Request", (datagrid, helper) => {
                   Request item = (Request)datagrid.SelectedItem;
                   int id = item.Id;
                   helper.DeleteRequest(id);
                }                        
            }
        };
    }
}
