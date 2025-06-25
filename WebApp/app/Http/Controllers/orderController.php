<?php

namespace App\Http\Controllers;

use App\Models\Order;
use App\Models\Pizza;
use App\Models\OrderLine;
use Illuminate\Http\Request;

class OrderController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {

    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        return view();
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $order = Order::create([
        'date' => now(),
        'status' => 'pending',
        ]);
        $orderlines = [];
        $cart = session('cart');
        foreach($cart as $cartitem)
        {   
            $orderline = OrderLine::create([
                'amount' => $cartitem['amount'],
                'size' => $cartitem['size'],
                'pizza_id' => $cartitem['pizza']->id,
            ]);
            $order->OrderLines()->save($orderline);
        }

        // Step 2: Create pizzas (or get existing ones)
        $pizzas = Pizza::findMany($request->pizzas);

        // Step 3: Create and attach order lines for this order
        foreach ($pizzas as $pizza) {
        $orderLine = new OrderLine([
        'size' => ['small', 'medium', 'large'][array_rand(['small', 'medium', 'large'])],
        'amount' => random_int(1,5),
        'pizza_id' => $pizza->id,
        ]);

        // Attach order line to the order (sets order_id FK)
        $order->orderLines()->save($orderLine);

        }
        redirect('/menu');
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        $order = Order::find($id);
        return view('orderpage', ['order'=> $order]);
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(string $id)
    {
        $order = Order::find($id);
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        $order = Order::find($id);
        $order->date = $request->date;
        $order->status = $request->status;
        $order->save();
        return redirect('/');
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        //
    }
}
