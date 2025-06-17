<?php

namespace Database\Factories;

use App\Models\OrderLine;
use App\Models\Order;
use App\Models\Pizza;
use Illuminate\Database\Eloquent\Factories\Factory;

class OrderLineFactory extends Factory
{
    protected $model = OrderLine::class;

    public function definition(): array
    {
        return [
            'size' => $this->faker->randomElement(['small', 'medium', 'large']),
            'amount' =>$this->faker->randomDigitNotZero(),
            // Associate with a random existing pizza or create one
            'pizza_id' => Pizza::inRandomOrder()->first()?->id ?? Pizza::factory(),
            // Associate with a random existing order or create one
            'order_id' => Order::inRandomOrder()->first()?->id ?? Order::factory(),
        ];
    }
}
