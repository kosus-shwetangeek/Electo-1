<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Staff.Master" AutoEventWireup="true" CodeBehind="AdminWelcome.aspx.cs" Inherits="ElectoSystem.Admin.AdminWelcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 align="center">Welcome to Electo Dashboard</h1>
     <!-- Small boxes (Stat box) -->
          <div class="row">
            <div class="col-lg-2 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-aqua">
                <div class="inner">
                  <h3>3</h3>
                  <p>Active House Elections</p>
                </div>
                <div class="icon">
                  <i class="ion ion-android-person-add"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-2 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-green">
                <div class="inner">
                  <h3>5</h3>
                  <p>Active Senate Elections</p>
                </div>
                <div class="icon">
                  <i class="ion ion-checkmark-circled"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-2 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h3>4</h3>
                  <p>House Nominations</p>
                </div>
                <div class="icon">
                  <i class="ion ion-home"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
            <div class="col-lg-2 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">
                  <h3>4</h3>
                  <p>Senate Nominations</p>
                </div>
                <div class="icon">
                  <i class="ion ion-briefcase"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
              <div class="col-lg-2 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">
                  <h3>4</h3>
                  <p>Total Voters</p>
                </div>
                <div class="icon">
                  <i class="ion ion-briefcase"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
              <div class="col-lg-2 col-xs-6">
              <!-- small box -->
              <div class="small-box bg-red">
                <div class="inner">
                  <h3>4</h3>
                  <p>Total Nominees</p>
                </div>
                <div class="icon">
                  <i class="ion ion-briefcase"></i>
                </div>
                <a href="#" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
              </div>
            </div><!-- ./col -->
          </div><!-- /.row -->
          <!-- Main row -->
</asp:Content>
