<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="intro-header">
        <div class="intro-message">
            <h1>Introducing JobRoll.</h1>
            <h3>JobRoll enables jobseekers and employers to find the right skill sets and employment that they need and 
                deserve. Our goal: to connect employers and jobseekers to have better opportunities and careers.</h3>
        </div>
    </div>
    <div class="features">
        <div class="feat-1">
            <div class="feat-message-1">
                <h2>Search.</h2>
                <h3>Employment-focused search, from hiring to salary rates and oppurtunities.</h3>
            </div>
        </div>
        <div class="feat-2">
            <div class="feat-message-2">
                <h2>Impress.</h2>
                <h3>Send your professional identity online to your prospective companies.</h3>
            </div>
        </div>
        <div class="feat-3">
            <div class="feat-message-3">
                <h2>Get hired. Fast.</h2>
                <h3>Employers can reach jobseekers through their job listing for instant communications.</h3>
            </div>
        </div>
        <div class="get-started">
            <h2>Let's get started.</h2><br />
            <a href="/Account/Register">Register now <span class="glyphicon glyphicon-chevron-right" style="color: gray;"></span></a>
        </div>
    </div>
    <br /><br />

    <footer>Copyright &copy; <%: DateTime.Now.Year %> Jobroll Ltd.<br />
            <a href="/About">About</a> &sdot; <a href="/Contact">Contact</a>
        </footer>
</asp:Content>
