import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { HttpModule } from "@angular/http";
import { FormsModule } from "@angular/forms";

import { AppRoutingModule } from "./app-routing.module";

import { AuthService } from "./_services/auth.service";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { LoginComponent } from "./login/login.component";

@NgModule({
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        HttpModule,
        AppRoutingModule,
        FormsModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        LoginComponent
    ],
    providers: [AuthService]
})
export class AppModule { }