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
	var indicator_module_1 = __webpack_require__(25);
	var app_component_1 = __webpack_require__(30);
	var AppModule = (function () {
	    function AppModule() {
	    }
	    AppModule = __decorate([
	        core_1.NgModule({
	            imports: [
	                platform_browser_1.BrowserModule,
	                indicator_module_1.IndicatorModule
	            ],
	            declarations: [
	                app_component_1.AppComponent
	            ],
	            bootstrap: [app_component_1.AppComponent]
	        }), 
	        __metadata('design:paramtypes', [])
	    ], AppModule);
	    return AppModule;
	}());
	exports.AppModule = AppModule;


/***/ },

/***/ 25:
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
	var indicator_list_component_1 = __webpack_require__(26);
	var indicator_details_component_1 = __webpack_require__(29);
	var IndicatorModule = (function () {
	    function IndicatorModule() {
	    }
	    IndicatorModule = __decorate([
	        core_1.NgModule({
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
	var indicator_service_1 = __webpack_require__(27);
	var IndicatorListComponent = (function () {
	    function IndicatorListComponent(indicatorService) {
	        this.indicatorService = indicatorService;
	    }
	    IndicatorListComponent.prototype.ngOnInit = function () {
	        this.indicators = this.indicatorService.getIndicators();
	    };
	    IndicatorListComponent = __decorate([
	        core_1.Component({
	            selector: 'indicator-list',
	            template: '<div>lalala</div>',
	            providers: [indicator_service_1.IndicatorService]
	        }), 
	        __metadata('design:paramtypes', [indicator_service_1.IndicatorService])
	    ], IndicatorListComponent);
	    return IndicatorListComponent;
	}());
	exports.IndicatorListComponent = IndicatorListComponent;


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
	var indicator_mock_1 = __webpack_require__(28);
	var IndicatorService = (function () {
	    function IndicatorService() {
	    }
	    IndicatorService.prototype.getIndicators = function () {
	        return indicator_mock_1.Indicators;
	    };
	    IndicatorService = __decorate([
	        core_1.Injectable(), 
	        __metadata('design:paramtypes', [])
	    ], IndicatorService);
	    return IndicatorService;
	}());
	exports.IndicatorService = IndicatorService;


/***/ },

/***/ 28:
/***/ function(module, exports) {

	"use strict";
	exports.Indicators = [
	    { id: '1', name: 'Indicator1', description: 'Description1' },
	    { id: '2', name: 'Indicator2', description: 'Description2' },
	    { id: '3', name: 'Indicator3', description: 'Description3' }
	];


/***/ },

/***/ 29:
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
	var IndicatorDetailsComponent = (function () {
	    function IndicatorDetailsComponent() {
	    }
	    IndicatorDetailsComponent = __decorate([
	        core_1.Component({
	            selector: 'indicator-details',
	            template: '<div>this is the indicator details</div>'
	        }), 
	        __metadata('design:paramtypes', [])
	    ], IndicatorDetailsComponent);
	    return IndicatorDetailsComponent;
	}());
	exports.IndicatorDetailsComponent = IndicatorDetailsComponent;


/***/ },

/***/ 30:
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
	        this.message = "I'm a cunt";
	    }
	    AppComponent = __decorate([
	        core_1.Component({
	            selector: 'my-app',
	            template: '<h1>My First Angular 2 App {{message}}</h1><indicator-list></indicator-list>'
	        }), 
	        __metadata('design:paramtypes', [])
	    ], AppComponent);
	    return AppComponent;
	}());
	exports.AppComponent = AppComponent;


/***/ }

});