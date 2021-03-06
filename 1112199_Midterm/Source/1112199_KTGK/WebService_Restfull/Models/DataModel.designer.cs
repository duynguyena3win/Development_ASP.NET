﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.36241
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebService_Restfull.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DBGIUAKY")]
	public partial class DataModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertProject(Project instance);
    partial void UpdateProject(Project instance);
    partial void DeleteProject(Project instance);
    partial void InsertTime(Time instance);
    partial void UpdateTime(Time instance);
    partial void DeleteTime(Time instance);
    partial void InsertUserProfile(UserProfile instance);
    partial void UpdateUserProfile(UserProfile instance);
    partial void DeleteUserProfile(UserProfile instance);
    #endregion
		
		public DataModelDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DBGIUAKYConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Project> Projects
		{
			get
			{
				return this.GetTable<Project>();
			}
		}
		
		public System.Data.Linq.Table<Time> Times
		{
			get
			{
				return this.GetTable<Time>();
			}
		}
		
		public System.Data.Linq.Table<UserProfile> UserProfiles
		{
			get
			{
				return this.GetTable<UserProfile>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Projects")]
	public partial class Project : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Nullable<int> _UserId;
		
		private int _ProjectId;
		
		private string _Name;
		
		private string _Description;
		
		private System.Nullable<double> _TotalTime;
		
		private EntitySet<Time> _Times;
		
		private EntityRef<UserProfile> _UserProfile;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(System.Nullable<int> value);
    partial void OnUserIdChanged();
    partial void OnProjectIdChanging(int value);
    partial void OnProjectIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnTotalTimeChanging(System.Nullable<double> value);
    partial void OnTotalTimeChanged();
    #endregion
		
		public Project()
		{
			this._Times = new EntitySet<Time>(new Action<Time>(this.attach_Times), new Action<Time>(this.detach_Times));
			this._UserProfile = default(EntityRef<UserProfile>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int")]
		public System.Nullable<int> UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					if (this._UserProfile.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ProjectId
		{
			get
			{
				return this._ProjectId;
			}
			set
			{
				if ((this._ProjectId != value))
				{
					this.OnProjectIdChanging(value);
					this.SendPropertyChanging();
					this._ProjectId = value;
					this.SendPropertyChanged("ProjectId");
					this.OnProjectIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NChar(50)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalTime", DbType="Float")]
		public System.Nullable<double> TotalTime
		{
			get
			{
				return this._TotalTime;
			}
			set
			{
				if ((this._TotalTime != value))
				{
					this.OnTotalTimeChanging(value);
					this.SendPropertyChanging();
					this._TotalTime = value;
					this.SendPropertyChanged("TotalTime");
					this.OnTotalTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Project_Time", Storage="_Times", ThisKey="ProjectId", OtherKey="ProjectId")]
		public EntitySet<Time> Times
		{
			get
			{
				return this._Times;
			}
			set
			{
				this._Times.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserProfile_Project", Storage="_UserProfile", ThisKey="UserId", OtherKey="UserId", IsForeignKey=true)]
		public UserProfile UserProfile
		{
			get
			{
				return this._UserProfile.Entity;
			}
			set
			{
				UserProfile previousValue = this._UserProfile.Entity;
				if (((previousValue != value) 
							|| (this._UserProfile.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._UserProfile.Entity = null;
						previousValue.Projects.Remove(this);
					}
					this._UserProfile.Entity = value;
					if ((value != null))
					{
						value.Projects.Add(this);
						this._UserId = value.UserId;
					}
					else
					{
						this._UserId = default(Nullable<int>);
					}
					this.SendPropertyChanged("UserProfile");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Times(Time entity)
		{
			this.SendPropertyChanging();
			entity.Project = this;
		}
		
		private void detach_Times(Time entity)
		{
			this.SendPropertyChanging();
			entity.Project = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Times")]
	public partial class Time : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _TimeId;
		
		private System.Nullable<int> _ProjectId;
		
		private System.Nullable<System.DateTime> _TimeBegin;
		
		private System.Nullable<System.DateTime> _TimeEnd;
		
		private EntityRef<Project> _Project;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTimeIdChanging(int value);
    partial void OnTimeIdChanged();
    partial void OnProjectIdChanging(System.Nullable<int> value);
    partial void OnProjectIdChanged();
    partial void OnTimeBeginChanging(System.Nullable<System.DateTime> value);
    partial void OnTimeBeginChanged();
    partial void OnTimeEndChanging(System.Nullable<System.DateTime> value);
    partial void OnTimeEndChanged();
    #endregion
		
		public Time()
		{
			this._Project = default(EntityRef<Project>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int TimeId
		{
			get
			{
				return this._TimeId;
			}
			set
			{
				if ((this._TimeId != value))
				{
					this.OnTimeIdChanging(value);
					this.SendPropertyChanging();
					this._TimeId = value;
					this.SendPropertyChanged("TimeId");
					this.OnTimeIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProjectId", DbType="Int")]
		public System.Nullable<int> ProjectId
		{
			get
			{
				return this._ProjectId;
			}
			set
			{
				if ((this._ProjectId != value))
				{
					if (this._Project.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnProjectIdChanging(value);
					this.SendPropertyChanging();
					this._ProjectId = value;
					this.SendPropertyChanged("ProjectId");
					this.OnProjectIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeBegin", DbType="DateTime")]
		public System.Nullable<System.DateTime> TimeBegin
		{
			get
			{
				return this._TimeBegin;
			}
			set
			{
				if ((this._TimeBegin != value))
				{
					this.OnTimeBeginChanging(value);
					this.SendPropertyChanging();
					this._TimeBegin = value;
					this.SendPropertyChanged("TimeBegin");
					this.OnTimeBeginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TimeEnd", DbType="DateTime")]
		public System.Nullable<System.DateTime> TimeEnd
		{
			get
			{
				return this._TimeEnd;
			}
			set
			{
				if ((this._TimeEnd != value))
				{
					this.OnTimeEndChanging(value);
					this.SendPropertyChanging();
					this._TimeEnd = value;
					this.SendPropertyChanged("TimeEnd");
					this.OnTimeEndChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Project_Time", Storage="_Project", ThisKey="ProjectId", OtherKey="ProjectId", IsForeignKey=true)]
		public Project Project
		{
			get
			{
				return this._Project.Entity;
			}
			set
			{
				Project previousValue = this._Project.Entity;
				if (((previousValue != value) 
							|| (this._Project.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Project.Entity = null;
						previousValue.Times.Remove(this);
					}
					this._Project.Entity = value;
					if ((value != null))
					{
						value.Times.Add(this);
						this._ProjectId = value.ProjectId;
					}
					else
					{
						this._ProjectId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Project");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserProfile")]
	public partial class UserProfile : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _UserName;
		
		private string _Email;
		
		private System.Nullable<System.DateTime> _Birthday;
		
		private EntitySet<Project> _Projects;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnBirthdayChanging(System.Nullable<System.DateTime> value);
    partial void OnBirthdayChanged();
    #endregion
		
		public UserProfile()
		{
			this._Projects = new EntitySet<Project>(new Action<Project>(this.attach_Projects), new Action<Project>(this.detach_Projects));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(56) NOT NULL", CanBeNull=false)]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(50)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Birthday", DbType="DateTime")]
		public System.Nullable<System.DateTime> Birthday
		{
			get
			{
				return this._Birthday;
			}
			set
			{
				if ((this._Birthday != value))
				{
					this.OnBirthdayChanging(value);
					this.SendPropertyChanging();
					this._Birthday = value;
					this.SendPropertyChanged("Birthday");
					this.OnBirthdayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="UserProfile_Project", Storage="_Projects", ThisKey="UserId", OtherKey="UserId")]
		public EntitySet<Project> Projects
		{
			get
			{
				return this._Projects;
			}
			set
			{
				this._Projects.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Projects(Project entity)
		{
			this.SendPropertyChanging();
			entity.UserProfile = this;
		}
		
		private void detach_Projects(Project entity)
		{
			this.SendPropertyChanging();
			entity.UserProfile = null;
		}
	}
}
#pragma warning restore 1591
