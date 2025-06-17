<?php
namespace Database\Seeders;

use Illuminate\Database\Seeder;
use App\Models\OrderLine;

class OrderLineSeeder extends Seeder
{
    public function run(): void
    {
        OrderLine::factory()
            ->count(20)
            ->create();
    }
}