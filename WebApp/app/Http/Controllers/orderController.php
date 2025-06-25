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
        $cart = session('cart');

        if (!$cart || count($cart) === 0) {
            return redirect()->back()->with('error', 'Your cart is empty.');
        }

        $order = Order::create([
            'date' => now(),
            'status' => 'pending',
        ]);
        foreach ($cart as $cartitem) {
            $orderline = new OrderLine([
                'amount' => $cartitem['amount'],
                'size' => $cartitem['size'],
                'pizza_id' => $cartitem['pizza']->id,
            ]);
            $order->orderLines()->save($orderline);
        }

        return view('orderpage', ['order' => $order]);
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
