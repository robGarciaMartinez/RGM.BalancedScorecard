webpackJsonp([0],{

/***/ 0:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var platform_browser_dynamic_1 = __webpack_require__(1);
	var app_module_1 = __webpack_require__(24);
	platform_browser_dynamic_1.platformBrowserDynamic().bootstrapModule(app_module_1.AppModule);


/***/ },

/***/ 24:
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(3);
	var platform_browser_1 = __webpack_require__(22);
	var http_1 = __webpack_require__(25);
	var indicator_module_1 = __webpack_require__(26);
	var home_module_1 = __webpack_require__(60);
	var app_component_1 = __webpack_require__(62);
	var app_routing_1 = __webpack_require__(63);
	var AppModule = (function () {
	    function AppModule() {
	    }
	    AppModule = __decorate([
	        core_1.NgModule({
	            imports: [
	                platform_browser_1.BrowserModule,
	                indicator_module_1.IndicatorModule,
	                home_module_1.HomeModule,
	                http_1.HttpModule,
	                http_1.JsonpModule,
	                app_routing_1.routing
	            ],
	            declarations: [
	                app_component_1.AppComponent
	            ],
	            providers: [
	                app_routing_1.appRoutingProviders
	            ],
	            bootstrap: [
	                app_component_1.AppComponent
	            ]
	        }), 
	        __metadata('design:paramtypes', [])
	    ], AppModule);
	    return AppModule;
	}());
	exports.AppModule = AppModule;


/***/ },

/***/ 26:
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(3);
	var platform_browser_1 = __webpack_require__(22);
	var indicator_list_component_1 = __webpack_require__(27);
	var indicator_details_component_1 = __webpack_require__(59);
	var IndicatorModule = (function () {
	    function IndicatorModule() {
	    }
	    IndicatorModule = __decorate([
	        core_1.NgModule({
	            imports: [
	                platform_browser_1.BrowserModule
	            ],
	            declarations: [
	                indicator_list_component_1.IndicatorListComponent,
	                indicator_details_component_1.IndicatorDetailsComponent
	            ],
	            exports: [
	                indicator_list_component_1.IndicatorListComponent
	            ],
	        }), 
	        __metadata('design:paramtypes', [])
	    ], IndicatorModule);
	    return IndicatorModule;
	}());
	exports.IndicatorModule = IndicatorModule;


/***/ },

/***/ 27:
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(3);
	var router_1 = __webpack_require__(28);
	var indicator_service_1 = __webpack_require__(58);
	var IndicatorListComponent = (function () {
	    function IndicatorListComponent(router, indicatorService) {
	        this.router = router;
	        this.indicatorService = indicatorService;
	    }
	    IndicatorListComponent.prototype.ngOnInit = function () {
	        var _this = this;
	        this.indicatorService.getIndicators()
	            .subscribe(function (indicators) { return _this.indicators = indicators; }, function (error) { return _this.errorMessage = error; });
	    };
	    IndicatorListComponent.prototype.navigateToDetails = function (indicator) {
	        this.router.navigate(['/indicator', indicator.code]);
	    };
	    IndicatorListComponent = __decorate([
	        core_1.Component({
	            selector: 'indicator-list',
	            templateUrl: 'src/indicators/indicator.list.component.html',
	            providers: [indicator_service_1.IndicatorService]
	        }), 
	        __metadata('design:paramtypes', [router_1.Router, indicator_service_1.IndicatorService])
	    ], IndicatorListComponent);
	    return IndicatorListComponent;
	}());
	exports.IndicatorListComponent = IndicatorListComponent;


/***/ },

/***/ 58:
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(3);
	var http_1 = __webpack_require__(25);
	var Observable_1 = __webpack_require__(5);
	var IndicatorService = (function () {
	    function IndicatorService(http) {
	        this.http = http;
	    }
	    IndicatorService.prototype.getIndicators = function () {
	        var page = 1;
	        return this.http.get("http://localhost:55004/api/indicators?page=" + page)
	            .map(this.extractData)
	            .catch(this.handleError);
	    };
	    IndicatorService.prototype.getIndicator = function (code) {
	        return this.http.get("http://localhost:55004/api/indicators/" + code)
	            .map(this.extractData)
	            .catch(this.handleError);
	    };
	    IndicatorService.prototype.extractData = function (res) {
	        var body = res.json();
	        return body || {};
	    };
	    IndicatorService.prototype.handleError = function (error) {
	        // In a real world app, we might use a remote logging infrastructure
	        // We'd also dig deeper into the error to get a better message
	        var errMsg = (error.message) ? error.message :
	            error.status ? error.status + " - " + error.statusText : 'Server error';
	        console.error(errMsg); // log to console instead
	        return Observable_1.Observable.throw(errMsg);
	    };
	    IndicatorService = __decorate([
	        core_1.Injectable(), 
	        __metadata('design:paramtypes', [http_1.Http])
	    ], IndicatorService);
	    return IndicatorService;
	}());
	exports.IndicatorService = IndicatorService;


/***/ },

/***/ 59:
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(3);
	var router_1 = __webpack_require__(28);
	var indicator_service_1 = __webpack_require__(58);
	var IndicatorDetailsComponent = (function () {
	    function IndicatorDetailsComponent(route, router, indicatorsService) {
	        this.route = route;
	        this.router = router;
	        this.indicatorsService = indicatorsService;
	    }
	    IndicatorDetailsComponent.prototype.ngOnInit = function () {
	        var _this = this;
	        //this.route.params.subscribe(
	        //params => {
	        //this.indicatorsService.getIndicator(params['code']).subscribe(
	        //indicator => this.indicator = indicator
	        //);
	        //}
	        //)
	        var code = this.route.snapshot.params['code'];
	        this.indicatorsService.getIndicator(code).subscribe(function (indicator) { return _this.indicator = indicator; });
	    };
	    IndicatorDetailsComponent = __decorate([
	        core_1.Component({
	            selector: 'indicator-details',
	            templateUrl: 'src/indicators/indicator.details.component.html',
	            providers: [indicator_service_1.IndicatorService]
	        }), 
	        __metadata('design:paramtypes', [router_1.ActivatedRoute, router_1.Router, indicator_service_1.IndicatorService])
	    ], IndicatorDetailsComponent);
	    return IndicatorDetailsComponent;
	}());
	exports.IndicatorDetailsComponent = IndicatorDetailsComponent;


/***/ },

/***/ 60:
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(3);
	var home_component_1 = __webpack_require__(61);
	var HomeModule = (function () {
	    function HomeModule() {
	    }
	    HomeModule = __decorate([
	        core_1.NgModule({
	            declarations: [
	                home_component_1.HomeComponent
	            ],
	            exports: [
	                home_component_1.HomeComponent
	            ],
	        }), 
	        __metadata('design:paramtypes', [])
	    ], HomeModule);
	    return HomeModule;
	}());
	exports.HomeModule = HomeModule;


/***/ },

/***/ 61:
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(3);
	var HomeComponent = (function () {
	    function HomeComponent() {
	    }
	    HomeComponent = __decorate([
	        core_1.Component({
	            selector: 'home',
	            template: '<div>Home</div>'
	        }), 
	        __metadata('design:paramtypes', [])
	    ], HomeComponent);
	    return HomeComponent;
	}());
	exports.HomeComponent = HomeComponent;


/***/ },

/***/ 62:
/***/ function(module, exports, __webpack_require__) {

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
	var core_1 = __webpack_require__(3);
	var AppComponent = (function () {
	    function AppComponent() {
	    }
	    AppComponent = __decorate([
	        core_1.Component({
	            selector: 'my-app',
	            templateUrl: 'src/app.component.html'
	        }), 
	        __metadata('design:paramtypes', [])
	    ], AppComponent);
	    return AppComponent;
	}());
	exports.AppComponent = AppComponent;


/***/ },

/***/ 63:
/***/ function(module, exports, __webpack_require__) {

	"use strict";
	var router_1 = __webpack_require__(28);
	var home_component_1 = __webpack_require__(61);
	var indicator_list_component_1 = __webpack_require__(27);
	var indicator_details_component_1 = __webpack_require__(59);
	var appRoutes = [
	    {
	        path: '',
	        component: home_component_1.HomeComponent
	    },
	    {
	        path: 'indicators',
	        component: indicator_list_component_1.IndicatorListComponent
	    },
	    {
	        path: 'indicator/:code',
	        component: indicator_details_component_1.IndicatorDetailsComponent
	    }
	];
	exports.appRoutingProviders = [];
	exports.routing = router_1.RouterModule.forRoot(appRoutes);


/***/ }

});
//# sourceMappingURL=app.js.map