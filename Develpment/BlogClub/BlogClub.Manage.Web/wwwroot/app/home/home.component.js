"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var auth_service_1 = require("../_services/auth.service");
var HomeComponent = (function () {
    function HomeComponent(authService) {
        this.authService = authService;
        this.isLogin = false;
    }
    HomeComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.isLogin = this.authService.checkLogin();
        if (this.isLogin) {
            this.authService.getUserInfo().then(function (res) {
                _this.userName = res.Data.UserName;
            });
        }
    };
    return HomeComponent;
}());
HomeComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: "my-home",
        templateUrl: "view.html",
        styleUrls: ["style.css"]
    }),
    __metadata("design:paramtypes", [typeof (_a = typeof auth_service_1.AuthService !== "undefined" && auth_service_1.AuthService) === "function" && _a || Object])
], HomeComponent);
exports.HomeComponent = HomeComponent;
var _a;
//# sourceMappingURL=home.component.js.map