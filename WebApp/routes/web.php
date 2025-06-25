<?php

use App\Http\Controllers\CartController;
use App\Http\Controllers\OrderController;
use App\Http\Controllers\ShopController;
use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    return view('homepage');
});

Route::get('/home', function () {
    return view('homepage');
})->name('home');
Route::get('/checkout', function () {
    return view('checkoutpage');
});

route::get('/menu', [ShopController::class, 'index'])->name('menu');
route::post('/menu/add', [ShopController::class,'addItem']);
route::post('/cart/store', [CartController::class, 'store']);
route::get('/cart', [CartController::class, 'index']);
Route::resources(
    ['orders' => OrderController::class]
);