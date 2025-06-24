<?php

namespace App\Http\Controllers;

use App\Models\OrderLine;
use App\Models\Pizza;
use App\Models\Order;
use Illuminate\Http\Request;
use PhpParser\Node\ArrayItem;
use function PHPUnit\Framework\isNull;
use function PHPUnit\Framework\returnArgument;

class ShopController extends Controller
{
    public function Index()
    {
        $pizzas = Pizza::all();
        return view('/menupage', ['pizzas' => $pizzas]);
    }

    public function RemoveItem()
    {
        $_SESSION['cart'];

        return redirect()->route('home');
    }
}
