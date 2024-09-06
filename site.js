        // Select all tab links and contents
        const tabLinks = document.querySelectorAll('.tab-link');
        const tabContents = document.querySelectorAll('.tab-content');

        // Function to switch tabs
        function switchTab(event) {
            const targetTab = event.target.getAttribute('data-tab');

            // Remove active classes from all tabs and contents
            tabLinks.forEach(link => link.classList.remove('active'));
            tabContents.forEach(content => content.classList.remove('active'));

            // Add active class to clicked tab and corresponding content
            event.target.classList.add('active');
            document.getElementById(targetTab).classList.add('active');
        }

        // Add click event listeners to all tab links
        tabLinks.forEach(link => {
            link.addEventListener('click', switchTab);
        });

        function openModal(title, image, price, description) {
            const modal = document.getElementById('wineModal');
            const modalContent = modal.querySelector('.bg-white');

            document.getElementById('modalTitle').textContent = title;
            document.getElementById('modalImage').src = image;
            document.getElementById('modalDescription').textContent = description;
            document.getElementById('modalPrice').textContent = price;

            // Mostrar el modal con un efecto de fade-in
            modal.classList.remove('hidden');
            setTimeout(() => {
                modalContent.classList.remove('opacity-0');
                modalContent.classList.add('opacity-100');
            }, 100);
        }

        function closeModal() {
            const modal = document.getElementById('wineModal');
            const modalContent = modal.querySelector('.bg-white');

            // Aplicar un efecto de fade-out
            modalContent.classList.remove('opacity-100');
            modalContent.classList.add('opacity-0');

            setTimeout(() => {
                modal.classList.add('hidden');
            }, 100); // Duración de la animación
        }