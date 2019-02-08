<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="section-hero">
        <%--<div class="intro-message">--%>
        <h1>Introducing JobRoll.</h1>
        <h3>JobRoll enables jobseekers and employers to find the right skill sets and employment that they need and 
                deserve. Our goal: to connect employers and jobseekers to have better opportunities and careers.</h3>
        <figure class="image-hero image-full-span"></figure>
        <%--</div>--%>
    </section>
    <section class="section-search">
        <div class="section-content">
            <h2>Search.</h2>
            <p>Employment-focused search, from hiring to salary rates and opportunities.</p>
            <figure class="image-search image-full-span image-feat"></figure>
        </div>
    </section>
    <section class="section-impress">
        <div class="section-content feat-right">
            <h2>Impress.</h2>
            <p>Send your professional identity online to your prospective companies.</p>
            <figure class="image-impress image-full-span image-feat"></figure>
        </div>
    </section>
    <section class="section-hire">
        <div class="section-content">
            <h2>Get hired. Fast.</h2>
            <p>Employers can reach jobseekers through their job listing for instant communication.</p>
            <figure class="image-hire image-full-span image-feat"></figure>
        </div>
    </section>
    <section class="section-get-started">
        <h2>Get started.</h2>
        <p>Kickstart your future today.</p>
        <br />
        <a class="btn-new" href="Account/Register" style="width: 88px;">Sign up ›</a>
    </section>
    <%--<br />
    <br />
    <br />
    <br />
    <br />--%>
</asp:Content>
