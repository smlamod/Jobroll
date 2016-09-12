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
            <div class="feat-text">
                <h2>Search.</h2>
                <h3>Employment-focused search, from hiring to salary rates and oppurtunities.</h3>
            </div>
        </div>
        <div class="feat-2">
            <div class="feat-text feat-right">
                <h2>Impress.</h2>
                <h3>Send your professional identity online to your prospective companies.</h3>
            </div>
        </div>
        <div class="feat-3">
            <div class="feat-text">
                <h2>Get hired. Fast.</h2>
                <h3>Employers can reach jobseekers through their job listing for instant communications.</h3>
            </div>
        </div>
        <div class="get-started">
            <a href="/Account/Register">
                <h2>Get started.</h2>
                <h3>Kickstart your future today.</h3>
                <p class="btn-new" style="width: 88px;">Sign up ›</p>
            </a>
        </div>
    </div>

    <%--<div class="footer">
        <div class="footer-text">
            Copyright &copy; <%: DateTime.Now.Year %> Jobroll Ltd.<br />
            <a href="/About">About</a> &sdot; <a href="/Contact">Contact</a>
        </div>
    </div>--%>
</asp:Content>
