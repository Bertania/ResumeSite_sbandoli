<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="JobHistory.aspx.cs" Inherits="Resume_sbandoli.JobHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Job History</h3>

        <section class="column-left">
            
            <asp:GridView ID="JobInfoGV" runat="server" AutoGenerateColumns="False" DataSourceID="JobTableDS" BorderStyle="Groove" BorderColor="White" CellPadding="3">
                <Columns>
                    <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                    <asp:BoundField DataField="CityState" HeaderText="City/State" />
                    <asp:BoundField DataField="RequiredWork" HeaderText="Responsibilities" />
                    <asp:BoundField DataField="EmployedDate" HeaderText="Employed Date" />
                </Columns>
                <RowStyle Font-Bold="False" />
            </asp:GridView>
            <br />

         </section>

    <asp:SqlDataSource ID="JobTableDS" runat="server" ConnectionString='<%$ ConnectionStrings:ContactInfoCS %>' SelectCommand="SELECT [CompanyName], [CityState], [RequiredWork], [EmployedDate] FROM [JobTable]"></asp:SqlDataSource>
           
</asp:Content>
