
/** @type {import('tailwindcss').Config} */
export default {
  content: ['./index.html', './src/**/*.{ts,tsx}'],
  theme: {
    extend: {
      colors: {
        brand: {
          50: '#eef9ff',
          100: '#d9f1ff',
          200: '#b3e4ff',
          300: '#85d3ff',
          400: '#4fbaff',
          500: '#1f9bff',
          600: '#0f77e6',
          700: '#0b5fc0',
          800: '#0d4e99',
          900: '#0e417c'
        }
      }
    },
  },
  plugins: [],
}
