<?php

// database/factories/IngredientFactory.php

namespace Database\Factories;

use App\Models\Ingredient;
use Illuminate\Database\Eloquent\Factories\Factory;

class IngredientFactory extends Factory
{
    protected $model = Ingredient::class;

    public function definition(): array
    {
        $array = ['gram', 'stuk', 'liter'];
        return [
            'name' => $this->faker->unique()->word(),
            'price' => $this->faker->randomFloat(2, 0.5, 10), // price between 0.5 and 10
            'amount' => $this->faker->numberBetween(10,100),
            'unit' => $array[random_int(0,2)]
        ];
    }
}
