<?php

// database/seeders/OrderSeeder.php

namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\Order;
use App\Models\OrderLine;
use App\Models\Pizza;

class OrderSeeder extends Seeder
{
    public function run(): void
    {
        Order::factory()
            ->count(10)
            ->create()
            ->each(function ($order) {
                // For each order, create 1–5 order lines
                OrderLine::factory()
                    ->count(rand(1, 5))
                    ->create([
                        'order_id' => $order->id,
                        'pizza_id' => Pizza::inRandomOrder()->first()?->id,
                    ]);
            });
    }
}
