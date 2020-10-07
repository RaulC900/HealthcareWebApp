# HealthcareWebApp

CREMENESCU RAUL-VALENTIN

TECHNICAL ASSESSMENT

I developed the app using ASP.NET, Dapper and MSSQL.

I organised the data in the database as follows:
Depot - contains medication present in depot (id - quantity).
Genders - 2 genders (I used it for the dropdown list of genders)
Site - table of sites.
SitesInventory - table which contains the medication stock of sites
(MedicationId - Quantity - SiteId).
SubjectsInventory - each subject's medication inventory.

The page ViewSites (Sites in the menu bar) displays a list of all sites. 
At the top of the page, I have placed a button "Add Sites". By pressing it, you will 
go to AddSites View where you can add a new site.
In the right part of the Sites table there are 3 operations Edit (CRUD), Delete (CRUD) and 
Order Medication For Site.

ViewSubjects
Same as ViewSites.

Depot
From the assessment text I could not figure out how depot fits in so I made a depot that 
contains Medication from which Sites can order. You can add new Medication by pressing the 
Add Medication To Depot button.
The quantity of each medication can be edited. A medication can be deleted.

Add Medication To Subjects
If the site is inactive or the order quantity is bigger than the available quantity present 
at the site, the order will not execute. I tried displaying an error here but could't figure it 
out in time.

Add Medication To Sites
If the order quantity is too big it will not execute.

I wanted to add a Users Signup/SignIn system but left it because of the short remaining time 
to complete the assessment.
