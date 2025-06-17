<?php

// database/factories/PizzaFactory.php

namespace Database\Factories;

use App\Models\Pizza;
use Illuminate\Database\Eloquent\Factories\Factory;

class PizzaFactory extends Factory
{
    protected $model = Pizza::class;

    public function definition(): array
    {
        return [
            'name' => $this->faker->unique()->word() . ' Pizza',
        ];
    }
}
