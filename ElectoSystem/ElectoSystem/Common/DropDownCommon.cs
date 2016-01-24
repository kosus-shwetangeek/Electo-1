using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectoSystem.Common
{
    /// <summary>
    /// This class will help to get values for different Dropdown used in UI
    /// </summary>
    public class DropDownCommon : DropDownDataSource, IDisposable
    {
        /// <summary>
        /// Object of the Entity Framework
        /// </summary>
        votinglivedbEntities entityFrame;

        /// <summary>
        /// This fucntion will return Class-Section data for dropdown binding 
        /// </summary>
        /// <returns>DropDownDataSource</returns>
        public List<DropDownDataSource> GetClassSectionDropDown()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllClassSectionPair] == null)
            {
                List<DropDownDataSource> lDropDown = new List<DropDownDataSource>();
                lDropDown.Add(new DropDownDataSource(0, string.Empty));

                entityFrame = new votinglivedbEntities();

                var lCollection = entityFrame.tclasssections.ToList().Where(x => x.Csc_IsDeleted == false || x.Csc_IsDeleted == null).Select(o => new DropDownDataSource { Key = o.Csc_Id, Value = o.Csc_DisplayName }).ToList();

                if (lCollection != null && lCollection.Count > 0)
                {
                    lDropDown.AddRange(lCollection);

                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllClassSectionPair, lDropDown, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);

                    return lDropDown;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return (List<DropDownDataSource>)HttpContext.Current.Cache[Common.UIConstants.cache_AllClassSectionPair];
            }
        }

        /// <summary>
        /// This fucntion will return Class data for dropdown binding 
        /// </summary>
        /// <returns>DropDownDataSource</returns>
        public List<DropDownDataSource> GetClassDropDown()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllClassPair] == null)
            {
                List<DropDownDataSource> lDropDown = new List<DropDownDataSource>();
                lDropDown.Add(new DropDownDataSource(0, string.Empty));

                entityFrame = new votinglivedbEntities();

                var lCollection = entityFrame.tclasses.ToList().Where(x => x.Cls_IsDeleted == false || x.Cls_IsDeleted == null).Select(o => new DropDownDataSource { Key = o.Cls_Id, Value = o.Cls_DisplayName }).ToList();

                if (lCollection != null && lCollection.Count > 0)
                {
                    lDropDown.AddRange(lCollection);

                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllClassPair, lDropDown, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);

                    return lDropDown;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return (List<DropDownDataSource>)HttpContext.Current.Cache[Common.UIConstants.cache_AllClassPair]; ;
            }
        }

        /// <summary>
        /// This fucntion will return Section data for dropdown binding 
        /// </summary>
        /// <returns>DropDownDataSource</returns>
        public List<DropDownDataSource> GetSectionDropDown()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllSectionPair] == null)
            {
                List<DropDownDataSource> lDropDown = new List<DropDownDataSource>();
                lDropDown.Add(new DropDownDataSource(0, string.Empty));

                entityFrame = new votinglivedbEntities();

                var lCollection = entityFrame.tsections.ToList().Where(x => x.Sec_IsDeleted == false || x.Sec_IsDeleted == null).Select(o => new DropDownDataSource { Key = o.Sec_Id, Value = o.Sec_DisplayName }).ToList();

                if (lCollection != null && lCollection.Count > 0)
                {
                    lDropDown.AddRange(lCollection);

                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllSectionPair, lDropDown, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);

                    return lDropDown;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return (List<DropDownDataSource>)HttpContext.Current.Cache[Common.UIConstants.cache_AllSectionPair];
            }
        }

        /// <summary>
        /// This fucntion will return House data for dropdown binding 
        /// </summary>
        /// <returns>DropDownDataSource</returns>
        public List<DropDownDataSource> GetHouseDropDown()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllHousePair] == null)
            {
                List<DropDownDataSource> lDropDown = new List<DropDownDataSource>();
                lDropDown.Add(new DropDownDataSource(0, string.Empty));

                entityFrame = new votinglivedbEntities();

                var lCollection = entityFrame.thouses.ToList().Where(x => x.Hus_IsDeleted == false || x.Hus_IsDeleted == null).Select(o => new DropDownDataSource { Key = o.Hus_Id, Value = o.Hus_Description }).ToList();

                if (lCollection != null && lCollection.Count > 0)
                {
                    lDropDown.AddRange(lCollection);

                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllHousePair, lDropDown, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);

                    return lDropDown;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return (List<DropDownDataSource>)HttpContext.Current.Cache[Common.UIConstants.cache_AllHousePair]; ;
            }
        }

        /// <summary>
        /// This fucntion will return Senate Designation data for dropdown binding 
        /// </summary>
        /// <returns>DropDownDataSource</returns>
        public List<DropDownDataSource> GetSenateDesignationDropDown()
        {
            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllSenateDesignationPair] == null)
            {
                List<DropDownDataSource> lDropDown = new List<DropDownDataSource>();
                lDropDown.Add(new DropDownDataSource(0, string.Empty));

                entityFrame = new votinglivedbEntities();

                var lCollection = entityFrame.tsenatedesignations.ToList().Where(x => x.Sen_IsDeleted == false || x.Sen_IsDeleted == null).Select(o => new DropDownDataSource { Key = o.Sen_Id, Value = o.Sen_Description }).ToList();

                if (lCollection != null && lCollection.Count > 0)
                {
                    lDropDown.AddRange(lCollection);

                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllSenateDesignationPair, lDropDown, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);

                    return lDropDown;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return (List<DropDownDataSource>)HttpContext.Current.Cache[Common.UIConstants.cache_AllSenateDesignationPair];
            }
        }

        /// <summary>
        /// This fucntion will return House Designation data for dropdown binding 
        /// </summary>
        /// <returns>DropDownDataSource</returns>
        public List<DropDownDataSource> GetHouseDesignationDropDown(int xiHouseId)
        {
            List<DropDownDataSource> lDropDown = new List<DropDownDataSource>();

            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllHouseDesignationPair] == null)
            {
                entityFrame = new votinglivedbEntities();

                var lAllHouseCollection = entityFrame.thousedesignations.ToList().Where(x => x.Hsd_IsDeleted == false || x.Hsd_IsDeleted == null).ToList();

                HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllHouseDesignationPair, lAllHouseCollection, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);

                if (xiHouseId > 0)
                {
                    lDropDown.Add(new DropDownDataSource(0, string.Empty));
                    lDropDown.AddRange(lAllHouseCollection.Where(x => x.Hsd_HouseId == xiHouseId).Select(o => new DropDownDataSource { Key = o.Hsd_Id, Value = o.Hsd_Description }).ToList());
                }

                return lDropDown;
            }
            else
            {
                lDropDown.Add(new DropDownDataSource(0, string.Empty));
                var lAllHouseCollection = (List<thousedesignation>)HttpContext.Current.Cache[Common.UIConstants.cache_AllHouseDesignationPair];
                lDropDown.AddRange(lAllHouseCollection.Where(x => x.Hsd_HouseId == xiHouseId).Select(o => new DropDownDataSource { Key = o.Hsd_Id, Value = o.Hsd_Description }).ToList());
                return lDropDown;
            }
        }

        public List<DropDownDataSource> GetHouseElectionDropDown()
        {
            List<DropDownDataSource> lDropDown = new List<DropDownDataSource>();

            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllHouseElectionsPair] == null)
            {
                entityFrame = new votinglivedbEntities();

                var lAllElectionCollection = entityFrame.thouseelections.ToList().ToList();

                if (lAllElectionCollection != null && lAllElectionCollection.Count > 0)
                {
                    lDropDown.Add(new DropDownDataSource(0, string.Empty));
                    lDropDown.AddRange(lAllElectionCollection.Select(o => new DropDownDataSource { Key = o.Hel_ElectionId, Value = o.Hel_Description }).ToList());
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllHouseElectionsPair, lAllElectionCollection, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return lDropDown;
            }
            else
            {
                lDropDown.Add(new DropDownDataSource(0, string.Empty));
                var lAllHouseCollection = (List<thouseelection>)HttpContext.Current.Cache[Common.UIConstants.cache_AllHouseElectionsPair];
                lDropDown.AddRange(lAllHouseCollection.Select(o => new DropDownDataSource { Key = o.Hel_ElectionId, Value = o.Hel_Description }).ToList());
                return lDropDown;
            }
        }

        public List<DropDownDataSource> GetSenateElectionDropDown()
        {
            List<DropDownDataSource> lDropDown = new List<DropDownDataSource>();

            if (HttpContext.Current.Cache[Common.UIConstants.cache_AllSenateElectionsPair] == null)
            {
                entityFrame = new votinglivedbEntities();

                var lAllElectionCollection = entityFrame.tsenateelections.ToList().ToList();

                if (lAllElectionCollection != null && lAllElectionCollection.Count > 0)
                {
                    lDropDown.Add(new DropDownDataSource(0, string.Empty));
                    lDropDown.AddRange(lAllElectionCollection.Select(o => new DropDownDataSource { Key = o.Sel_ElectionId, Value = o.Sel_Description }).ToList());
                    HttpContext.Current.Cache.Insert(Common.UIConstants.cache_AllSenateElectionsPair, lAllElectionCollection, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return lDropDown;
            }
            else
            {
                lDropDown.Add(new DropDownDataSource(0, string.Empty));
                var lAllHouseCollection = (List<tsenateelection>)HttpContext.Current.Cache[Common.UIConstants.cache_AllSenateElectionsPair];
                lDropDown.AddRange(lAllHouseCollection.Select(o => new DropDownDataSource { Key = o.Sel_ElectionId, Value = o.Sel_Description }).ToList());
                return lDropDown;
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }

    /// <summary>
    /// This class represents key value pair which we are using to get dropdown data to bind perticular.
    /// Please Note this is Integer-String pair.
    /// </summary>
    public class DropDownDataSource
    {
        //TODO: need to create Key as a string. Currently we have onlt integer type

        int key;
        string value;

        public int Key
        {
            get { return key; }
            set { key = value; }
        }

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public DropDownDataSource()
        {

        }

        public DropDownDataSource(int xiKey, string xiValue)
        {
            this.Key = xiKey;
            this.Value = xiValue;
        }
    }
}